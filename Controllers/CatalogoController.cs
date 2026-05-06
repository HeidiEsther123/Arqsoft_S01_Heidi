using Catalogo.Models;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Controllers
{
    public class CatalogoController : Controller
    {
        private static List<Item> _items = new()
        {
            new Item
            {
                Id = 1,
                Titulo = "Devil May Cry",
                Genero = "Hack and Slash",
                Ano = 2001,
                Consola = "PlayStation 2",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item
            {
                Id = 2,
                Titulo = "Castlevania: Symphony of the Night",
                Genero = "Metroidvania",
                Ano = 1997,
                Consola = "PlayStation",
                Descripcion = "Videojuego que trata de un cazador..."
            },
            new Item
            {
                Id = 3,
                Titulo = "NieR: Automata",
                Genero = "Action RPG",
                Ano = 2017,
                Consola = "PlayStation 4",
                Descripcion = "Videojuego que combina acción y narrativa filosófica..."
            },
               new Item
            {
                Id = 4,
                Titulo = "Sonic",
                Genero = "Carreras",
                Ano = 1991,
                Consola = "Sega Genesis",
                Descripcion = "Videojuego de carreras protagonizado por el icónico erizo azul..."
            },
                new Item
            {
                Id = 5,
                Titulo = "Cooking Mama",
                Genero = "Simulación",
                Ano = 2006,
                Consola = "Nintendo DS",
                Descripcion = "Videojuego de simulación de cocina donde los jugadores preparan diversos platos siguiendo instrucciones paso a paso."
            },
                               new Item
            {
                Id = 6,
                Titulo = "Minecraft",
                Genero = "Exploracion",
                Ano = 2011,
                Consola = "PC",
                Descripcion = "Videojuego de construcción y exploración en un mundo abierto compuesto por bloques."
            },
                                              new Item
            {
                Id = 7,
                Titulo = "League of Legends",
                Genero = "MOBA",
                Ano = 2009,
                Consola = "PC",
                Descripcion = "Videojuego de estrategia en tiempo real donde los jugadores controlan campeones con habilidades únicas para destruir la base enemiga."
            },
                                                             new Item
            {
                Id = 8,
                Titulo = "Valorant",
                Genero = "Shooter",
                Ano = 2020,
                Consola = "PC",
                Descripcion = "Videojuego de disparos en primera persona donde los jugadores controlan agentes con habilidades únicas para competir en partidas tácticas por equipos."
            },
        };

      
        public IActionResult Index(string? genero)
        {
            var resultado = string.IsNullOrEmpty(genero)
                ? _items
                : _items.Where(i => i.Genero == genero).ToList();

            ViewBag.Generos = _items.Select(i => i.Genero).Distinct().ToList();
            ViewBag.GeneroActual = genero;

            return View(resultado);
        }

      
        public IActionResult Detalle(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            return item == null ? NotFound() : View(item);
        }

    
        public IActionResult Agregar()
        {
            return View();
        }

       
        [HttpPost]
        public IActionResult Agregar(Item item)
        {
            item.Id = _items.Count + 1;
            _items.Add(item);
            return RedirectToAction("Index");
        }
    }
}
