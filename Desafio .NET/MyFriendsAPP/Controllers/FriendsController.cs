using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyFriendsAPP.Data;
using MyFriendsAPP.Models;

namespace MyFriendsAPP.Controllers
{
    public class FriendsController : Controller
    {
        private readonly MvcFriendContext _context;

        public FriendsController(MvcFriendContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index(string friendNome, [Bind("Id,Nome,Rua,Cidade,Estado,Pais,Latitude,Longitude")] Friend friend)
        {
   

            IQueryable<string> nomeQuery = from m in _context.Friend
                                           orderby m.Nome
                                           select m.Nome;

            var friends = from m in _context.Friend
                          select m;

            friends = friends.Where(x => x.Nome != friendNome).OrderBy(Friend => Friend.Distancia);

            var friendNomeVM = new FriendNomeViewModel
            {
                Nomes = new SelectList(await nomeQuery.Distinct().ToListAsync()),
                Friends = await friends.ToListAsync()

            };

            var friendsCalculo = from m in _context.Friend
                                 select m;

            var Lista2 = await friends.ToListAsync();

            double lat = 0;

            double longi = 0;

            double lat2 = 0;

            double long2 = 0;

            double dlat = 0;

            double dlong = 0;

            double a = 0;

            double c = 0;

            double resultado = 0;

            if (!string.IsNullOrEmpty(friendNome))
            {
                
                friendsCalculo = friendsCalculo.Where(x => x.Nome == friendNome);
                var Lista = await friendsCalculo.ToListAsync();
                lat = Lista[0].Latitude * Math.PI / 180;
                longi = Lista[0].Longitude * Math.PI / 180;

                for (int re = 0; re < Lista2.Count(); re++)
                {
                    string nomeFor = Lista2[re].Nome;

                    lat2 = (Lista2[re].Latitude * Math.PI) / 180;
                    long2 = (Lista2[re].Longitude * Math.PI) / 180;

                    dlat = lat2 - lat;
                    dlong = long2 - longi;

                    a = (Math.Sin(dlat / 2) * Math.Sin(dlat / 2)) + (Math.Cos(lat) * Math.Cos(lat2) * Math.Sin(dlong / 2) * Math.Sin(dlong / 2));

                    c = 2 * Math.Asin(Math.Sqrt(a));

                    resultado = 6371 * c * 1000;
                    resultado = Convert.ToInt32(resultado);

                    _context.Database.ExecuteSqlCommand("Update dbo.Friend Set Distancia = {0} where Nome = {1}", resultado, nomeFor);
                }
               
            }


           friends = friends.Where(x => x.Nome != friendNome).OrderBy(Friend => Friend.Distancia);

            var friendNomeVM2 = new FriendNomeViewModel
            {
                Nomes = new SelectList(await nomeQuery.Distinct().ToListAsync()),
                Friends = await friends.ToListAsync()

            };

            return View(friendNomeVM2);


        }



        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
 

            var friend = await _context.Friend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        public IActionResult Create()
        {
            return View();
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Rua,Cidade,Estado,Pais,Latitude,Longitude, Distancia")] Friend friend)
        {
            if (ModelState.IsValid)
            {
                _context.Add(friend);
                _context.Add(friend.Distancia = 0);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend.FindAsync(id);
            if (friend == null)
            {
                return NotFound();
            }
            return View(friend);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Rua,Cidade,Estado,Pais,Latitude,Longitude")] Friend friend)
        {
            if (id != friend.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(friend);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FriendExists(friend.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(friend);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var friend = await _context.Friend
                .FirstOrDefaultAsync(m => m.Id == id);
            if (friend == null)
            {
                return NotFound();
            }

            return View(friend);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var friend = await _context.Friend.FindAsync(id);
            _context.Friend.Remove(friend);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FriendExists(int id)
        {
            return _context.Friend.Any(e => e.Id == id);
        }

    }
}
