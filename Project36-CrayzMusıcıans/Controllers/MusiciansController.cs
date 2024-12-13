using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Project36_CrazyMusicians.Model;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Project36_CrazyMusicians.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MusiciansController : ControllerBase
    {

        private static List<Musician> _musicians = new List<Musician>()
        {
            new Musician{ID = 1, Name = "Ahmet Çalgı", Profession = "Ünlü Çalgı Çalar", FunFeature = "Her zaman yanlış nota çalar, ama çok eğlenceli."},
            new Musician{ID = 2, Name = "Zeynep Melodi", Profession = "Popüler Melodi Yazarı", FunFeature = "Şarkıları yanlış anlaşılır ama çok popüler."},
            new Musician{ID = 3, Name = "Cemil Akor", Profession = "Çılgın Akorist", FunFeature = "Akorları sık değiştirir, ama şaşırtıcı derecede yetenekli."},
            new Musician{ID = 4, Name = "Fatma Nota", Profession = "Sürpriz Nota Üreticisi", FunFeature = "Nota üretirken sürekli sürprizler hazırlar."},
            new Musician{ID = 5, Name = "Hasan Ritim", Profession = "Ritim Canavarı", FunFeature = "Her ritmi kendi tarzında yapar, hiç uymaz ama komiktir."},
            new Musician{ID = 6, Name = "Elif Armoni", Profession = "Armoni Ustası", FunFeature = "Armonilerini bazen yanlış çalar, ama çok yaratıcıdır."},
            new Musician{ID = 7, Name = "Ali Perde", Profession = "Perde Uygulayıcı", FunFeature = "Her perdeyi farklı şekilde çalar, her zaman sürprizlidir."},
            new Musician{ID = 8, Name = "Ayşe Rezonans", Profession = "Rezonans Uzmanı", FunFeature = "Rezonans konusunda uzman, ama bazen çok gurultu çıkarır."},
            new Musician{ID = 9, Name = "Murat Ton", Profession = "Tonlama Meraklısı", FunFeature = "Tonlamalarındaki farklılıklar bazen komik, ama oldukça ilginç."},
            new Musician{ID = 10, Name = "Selin Akor", Profession = "Akor Sihirbazı", FunFeature = "Akorları değiştirdiğinde bazen sihirli bir hava yaratır."}
        };


        [HttpGet]
        public ActionResult<IEnumerable<Musician>> GetAll()
        {
            return Ok(_musicians);
        }

        [HttpGet("{id:int:min(1)}")]
        public ActionResult<Musician> GetMusicians(int id)
        {
            var musicians = _musicians.FirstOrDefault(a => a.ID == id);

            if (musicians == null)
            {
                return NotFound($"Müzisyen Id {id} bulunamadı");
            }

            return Ok(musicians);
        }

        [HttpGet("musicians/{musiciansName:alpha}")]
        public ActionResult<IEnumerable<Musician>> GetMusiciansByName(string musiciansName)

        {
            var musicians = _musicians.Where(m => m.Name.Contains(musiciansName, StringComparison.OrdinalIgnoreCase));

            if (!musicians.Any())
            {
                return NotFound($"Müzisyen adı {musiciansName} bulunamadı");
            }

            return Ok(musicians);
        }

        [HttpGet("ID-range")]
        public ActionResult<IEnumerable<Musician>> GetMusiciansByIdRange([FromQuery] int minId, [FromQuery] int maxId)
        {
            var IdFilteredMusicians = _musicians.Where(m => m.ID >= minId && m.ID <= maxId);


            return Ok(IdFilteredMusicians);
        }

        [HttpPost]
        public ActionResult<Musician> CreateMusician([FromBody] Musician musician)
        {
            var Id = _musicians.Max(m => m.ID) + 1;
            musician.ID = Id;
            _musicians.Add(musician);

            return CreatedAtAction(nameof(GetMusicians), new { id = musician.ID }, musician);
        }

        [HttpPut("update/{id:int:min(1)}/{updatedName}")]
        public ActionResult<Musician> UpdateMusician(int id, string updatedName)
        {
            var musician = _musicians.FirstOrDefault(m => m.ID == id);
            if (musician == null)
            {
                return NotFound($"Müzisyen Id {id} bulunamadı");
            }
            musician.Name = updatedName;
            return Ok(musician);
        }

        [HttpPut("update/{id:int:min(1)}")]
        public ActionResult<Musician> UpdateMusician(int id, [FromBody] Musician updatedMusician)
        {
            var musician = _musicians.FirstOrDefault(m => m.ID == id);
            if (musician == null)
            {
                return NotFound($"Müzisyen Id {id} bulunamadı");
            }
            musician.Name = updatedMusician.Name;
            musician.Profession = updatedMusician.Profession;
            musician.FunFeature = updatedMusician.FunFeature;
            return Ok(musician);
        }

        [HttpDelete("delete/{id:int:min(1)}")]
        public ActionResult DeleteMusician(int id)
        {
            var musician = _musicians.FirstOrDefault(m => m.ID == id);
            if (musician == null)
            {
                return NotFound($"Müzisyen Id {id} bulunamadı");
            }
            _musicians.Remove(musician);
            return Ok("Başarıyla Silindi.");

        }

        [HttpPatch("update/{id:int:min(1)}")]
        public IActionResult UpdateMusicianName(int id, [FromBody] Musician musician)
        {
            var existingmusician =_musicians.FirstOrDefault(m => m.ID == id);
            if (existingmusician == null)
            {
                return NotFound($"Müzisyen Id {id} bulunamadı.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            existingmusician.Name = musician.Name;

            return Ok(existingmusician);
        }





    }

}

