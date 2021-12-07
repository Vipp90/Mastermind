using Mastermind.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Microsoft.AspNetCore.Http;

namespace Mastermind.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private Database _context;
        private List<Highscores> Scores = new List<Highscores>();
        private static int Score;
      
        public HomeController(ILogger<HomeController> logger, Database context)
        {
            _logger = logger;
            _context = context;

        }
        public void updatedata()
        {
            Scores = _context.Table.ToList();
        }

        public string Get_sessionId() 
        {
          return HttpContext.Session.Id;
        }
        public Game_info Download_game_info(string SessionID)
        {
            var game = _context.Game_info.Include(m=> m.Code).First(m => m.SessionID == SessionID);
            return game;
        }
        public string Download_game_mode(string sessionID)
        {
            var game = _context.Game_info.SingleOrDefault(m => m.SessionID == sessionID);
            return game.Mode;
        }

        [HttpPost]
        public JsonResult SetCode(string a, string b, string c, string d, string name, string mode, string sessionID )
        {
            Game_info game = new Game_info();
            if (_context.Game_info.Any(m => m.SessionID == sessionID) == true)
            {
                Clean_game(sessionID);
            }
            DateTime date = DateTime.Today;
            Code code = new Code();
            code.FirstColor = a;
            code.SecondColor = b;
            code.ThirdColor = c;
            code.FourthColor = d;
       
            game.Code = code;
            game.Mode = mode;
            game.Player_name = name;
            game.SessionID = sessionID;
            game.date = date;
            _context.Game_info.Add(game);
            _context.SaveChanges();
            return Json(new { newUrl = Url.Action("Game", "Home") });
        }
        public string[] ReturnKod(string SessionID) 
        {
             Game_info game = new Game_info();
            game = Download_game_info(SessionID);           
            return game.Code.ToString2(); ;
        }
        public string Check(string e, string f, string g, string h, string SessionId)
        {
            Game_info game = new Game_info();
            game = Download_game_info(SessionId);
            string[] code= { game.Code.FirstColor, game.Code.SecondColor, game.Code.ThirdColor, game.Code.FourthColor};
            string[] data = { e, f, g, h };
            string result = "";
            
             for (int i = 0; i < 4; i++)
            {
                if (code[i] != "" || data[i] != "") 
                {
                    bool x = code[i] == data[i];
                    if (x == true)
                    {
                        result = result + "b ";
                        code[i] = "";
                        data[i] = "";
                    }
                }
                
            }
                for (int j = 0; j < 4; j++)
                {
                    for (int k = 0; k < 4; k++)
                    {
                    if (code[j] != "" && data[k] != "") 
                    {
                        if (code[j].Contains(data[k]) == true)
                        {
                            code[j] = "";
                            data[k] = "";
                            result = result + "w ";
                        }
                    }
                    }        
                }
            return result;
               
        }
        public IActionResult Winner()
        {
            return View();
        }
        public IActionResult Index()
        {
            HttpContext.Session.SetString("mysession", "mySessionValue");
            return View();
        }

        public IActionResult Game()
        {
            return View();
        }
        
        public void Add_score(int score)
        {
            Score = score;
        }
        public void Update_highscores(int score, string sessionID)
        {
            Score = score;
            Game_info game = new Game_info();
            game = Download_game_info(sessionID);
            if (game.Player_name != "" && Score != 0) 
            {
                updatedata();
                Highscores position = new Highscores();
                var poz = _context.Table.SingleOrDefault(m => m.Name == game.Player_name);
                if (poz != null)
                {
                    if (poz.Score > Score)
                    { poz.Score = Score; }
                }
                else
                {
                    position.Name = game.Player_name;
                    position.Score = Score;
                    _context.Table.Add(position);
                }
                _context.Game_info.Remove(game);
                _context.SaveChanges();
            }
        }

        public void Clean_game(string sessionID)
        {
            Game_info game = new Game_info();
            game = Download_game_info(sessionID);
            _context.Game_info.Remove(game);
            _context.SaveChanges();
        }
        public void UpdateRandomCode(string c1, string c2, string c3, string c4, string sessionID)
        {
            var poz = _context.Game_info.SingleOrDefault(m => m.SessionID == sessionID);
            poz.Code.FirstColor = c1; poz.Code.SecondColor = c2; poz.Code.ThirdColor = c3; poz.Code.FourthColor = c4;
            _context.SaveChanges();
        }
        public List<String> Download_table()
        {
            updatedata();
            List<String> list = new List<String>();
            Scores = Scores.OrderBy(o => o.Score).ToList();
                   
            for (int i = 0; i < Scores.Count; i++)
            { list.Add(Scores[i].toString2());
                if (i == 9)
                { i = Scores.Count; }
            }    
            return list;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
