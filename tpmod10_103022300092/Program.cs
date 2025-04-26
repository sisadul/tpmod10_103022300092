
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public class Mahasiswa
{
    public string nama { get; set; }
    public string NIM { get; set; }
}

[Route("api/[controller]")]
[ApiController]

public class MahasiswaController : ControllerBase
{
    private static List<Mahasiswa> daftarMahasiswa = new List<Mahasiswa>
    {
        new Mahasiswa{ nama = "Abdul Aziz Saepurohmat", NIM = "103022300092"},
        new Mahasiswa{ nama = "Reza Indra Maulan", NIM = "103022300109"},
        new Mahasiswa{ nama = "Deru Djuharianto", NIM = "103022300101 "},
        new Mahasiswa{ nama = "Edsel Septa Haryanto", NIM = "103022300016"},
        new Mahasiswa{ nama = "Gusti Agung Raka Darma Putra Kepakisan", NIM = "103022300088 "},
    };
    [HttpGet]
    public ActionResult<List<Mahasiswa>> GetMahasiswa()
    {
        return Ok(daftarMahasiswa);
    }

    [HttpGet("{idx}")]
    public ActionResult<Mahasiswa> GetIdxMahasiswa(int idx)
    {
        if (idx >= daftarMahasiswa.Count || idx < 0)
        {
            return NotFound();
        }
        return Ok(daftarMahasiswa[idx]);
    }

    [HttpPost]
    public ActionResult Post([FromBody] Mahasiswa mahasiswa)
    {
        daftarMahasiswa.Add(mahasiswa);
        return Ok();
    }

    [HttpDelete("{idx}")]

    public ActionResult Delete(int idx)
    {
        if (idx >= daftarMahasiswa.Count || idx < 0)
        {
            return NotFound();
        }
        daftarMahasiswa.RemoveAt(idx);
        return Ok();
    }
}
