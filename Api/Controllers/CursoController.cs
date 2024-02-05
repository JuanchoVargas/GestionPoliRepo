using System.Text;
using DevExtreme.AspNet.Data;
using ESAP.Sirecec.Data;
using ESAP.Sirecec.Data.Api.Authorization;
using ESAP.Sirecec.Data.Api.Utils;
using ESAP.Sirecec.Data.Core;
using ESAP.Sirecec.Data.Model;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Web.Resource;
using Newtonsoft.Json;

namespace ESAP.Sirecec.Data.Api.Controllers
{
	[@Authorize]
	[ApiController]
	[Route("curso")]
	// [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
	// CRUD => CREATE READ UPDATE DELETE
	public class CursoController : BaseController
	{
		private readonly DataContext _db;
		private readonly ILogger _logger;
		private readonly IConfiguration _config;
		private readonly IHttpContextAccessor _context;

		public CursoController(DataContext context, IHttpContextAccessor httpContextAccessor, ILogger<CursoController> logger, IConfiguration config)
		{
			_db = context;
			_logger = logger;
			_config = config;
			_context = httpContextAccessor;
		}

		[HttpPost("ed")] // /api/curso/ed => CREATE - UPDATE
		public ActionResult Edit(Curso item)
		{
			var u = User;

			// Registro nuevo: CREATE
			if (item.Id == 0)
			{
				var obj = (Curso)item.CopyTo(new Curso());
				obj.CreadoPor = GetUserId();
				obj.CreadoEl = DateTime.Now;
				_db.Curso.Add(obj);
				_db.SaveChanges();
				return Ok(obj);
			}
			else
			{
				// Registro existente: EDIT
				var current = _db.Curso.First(o => o.Id == item.Id);
				if (current != null)
				{
					var final = (Curso)item.CopyTo(current);
					final.EditadoPor = GetUserId();
					final.EditadoEl = DateTime.Now;
					_db.SaveChanges();
					return Ok(final);
				}

				return Ok(item);
			}
		}

		[HttpPost("by-curso-id")]
		public ActionResult ByCursoId([FromBody] int cursoId)
		{
			var items = _db.CursoTema?.Where(o => o.CursoId == cursoId).ToList();
			return Ok(items);
		}

		[HttpPost("by-curso-id-participantes")]
		public ActionResult ByCursoIdParticipantes([FromBody] int cursoId)
		{
			var items = _db.CursoUsuario?.Where(o => o.CursoId == cursoId).ToList();
			return Ok(items);
		}

		[HttpPost("ed-tema")] // /api/curso/ed => CREATE - UPDATE
		public ActionResult EditTemas(CursoTemaModel curso)
		{
			var tId = curso.CursoId;
			var temasActuales = _db.CursoTema.Where(o => o.CursoId == tId).ToList();
			_db.CursoTema.RemoveRange(temasActuales);
			_db.SaveChanges();
			foreach (var item in curso.Temas)
			{
				var obj = (CursoTema)item.CopyTo(new CursoTema());
				obj.CreadoPor = GetUserId();
				obj.CreadoEl = DateTime.Now;
				_db.CursoTema.Add(obj);
				_db.SaveChanges();
			}
			return Ok();
		}

		[HttpPost("ed-encuesta")] // /api/curso/ed => CREATE - UPDATE
		public ActionResult EditEncuestas(CursoEncuestaModel curso)
		{
			var eId = curso.CursoId;
			var encuestasActuales = _db.CursoEncuesta.Where(o => o.CursoId == eId).ToList();
			_db.CursoEncuesta.RemoveRange(encuestasActuales);
			_db.SaveChanges();
			foreach (var item in curso.Encuestas)
			{
				var obj = (CursoEncuesta)item.CopyTo(new CursoEncuesta());
				obj.CreadoPor = GetUserId();
				obj.CreadoEl = DateTime.Now;
				_db.CursoEncuesta.Add(obj);
				_db.SaveChanges();
			}
			return Ok();
		}

		[HttpPost("ed-archivo")] // /api/curso/ed-archivo
		public ActionResult EditArchivo()
		{
			// Documento
			var str = Request.Form["documento"];
			var item = JsonConvert.DeserializeObject<CursoDocumento>(str);

			// Archivo
			var files = Request.Form.Files;
			if (files.Count > 0)
			{
				var file = files[0];
				var fileBase = _config["Path:FilesPath"];
				// var uniqueFileName = file.FileName.GetUniqueFileName();
				var ext = Path.GetExtension(Path.GetFileName(file.FileName)).ToLower();
				var uniqueFileName = Guid.NewGuid().ToString().ToLower() + ext;
				var uploadDir = Path.Combine(fileBase, ext == ".pdf" ? "doc" : "img");
				var filePath = Path.Combine(uploadDir, uniqueFileName);
				file.CopyTo(new FileStream(filePath, FileMode.Create));
				item.ArchivoNombre = uniqueFileName;
			}

			if (item.Id == 0)
			{
				var obj = (CursoDocumento)item.CopyTo(new CursoDocumento());
				obj.CreadoPor = GetUserId();
				obj.CreadoEl = DateTime.Now;
				_db.CursoDocumento.Add(obj);
				_db.SaveChanges();
				return Ok(obj);
			}
			else
			{
				var current = _db.CursoDocumento.First(o => o.Id == item.Id);
				if (current != null)
				{
					var final = (CursoDocumento)item.CopyTo(current);
					final.EditadoPor = GetUserId();
					final.EditadoEl = DateTime.Now;
					_db.SaveChanges();
					return Ok(final);
				}
				return Ok(item);
			}
		}




		[HttpGet("dep/{dependenciaId?}")] // /api/curso/dep/13 o 14
		[Authorization.AllowAnonymous]
		public ActionResult GetByDependenciaId(int? dependenciaId = null)
		{
			var items = _db.Cursos.Where(o => o.DependenciaId == dependenciaId);
			return Ok(items);
		}

		[HttpGet("all")] // /api/curso/all
		[Authorization.AllowAnonymous]
		public ActionResult GetAll()
		{
			var items = _db.Cursos.ToList();
			return Ok(items);
		}

		[HttpGet("published")] // /api/curso/published
		[Authorization.AllowAnonymous]
		public ActionResult GetPublished()
		{
			var items = _db.Cursos.Where(o => o.Publicado == true).ToList();
			return Ok(items);
		}

		[HttpGet("cursos-temas")]// api/curso/temas
		public ActionResult CursosTemas()
		{
			var items = _db.CursosTemas?.ToList();
			return Ok(items);
		}

		[HttpGet("cursos-documentos")]// api/curso/temas
		public ActionResult CursosDocumentos()
		{
			var items = _db.CursosDocumentos?.ToList();
			return Ok(items);
		}


		[HttpGet("{itemId?}")] // /api/curso/5 => CREATE - 
		[Authorization.AllowAnonymous]
		public ActionResult Get(int? itemId = null)
		{
			var item = _db.Cursos.FirstOrDefault(o => o.Id == itemId);
			return Ok(item);
		}

		[HttpPost("fechas")] // /curso/fechas
		public ActionResult TemasDx([FromBody] int cursoId)
		{
			var items = _db.CursoFecha?.Where(o => o.CursoId == cursoId).ToList();
			return Ok(items);
		}

		[HttpPost("archivos-dx")] // /api/curso/archivos-dx
		public ActionResult ArchivosDx()
		{
			StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var str = reader.ReadToEndAsync().Result;
			var opts = JsonConvert.DeserializeObject<LoadOptions>(str);
			opts.PrimaryKey = new[] { "Id" };
			var data = JsonConvert.DeserializeObject<GenericModel>(opts.UserData);
			var items = _db.CursosDocumentos.Where(o => o.CursoId == data.id).OrderBy(o => o.Nombre).ToList();
			var loadResult = DataSourceLoader.Load(items, opts);
			return Ok(loadResult);
		}

		[HttpPost("temas-dx")] // /api/curso/temas-dx
		public ActionResult TemasDx()
		{
			StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var str = reader.ReadToEndAsync().Result;
			var opts = JsonConvert.DeserializeObject<LoadOptions>(str);
			opts.PrimaryKey = new[] { "Id" };
			var data = JsonConvert.DeserializeObject<GenericModel>(opts.UserData);
			var items = _db.CursosTemas.Where(o => o.CursoId == data.id).OrderBy(o => o.TemaNombre).ToList();
			var loadResult = DataSourceLoader.Load(items, opts);
			return Ok(loadResult);
		}

		[HttpPost("participantes-dx")] // /api/curso/temas-dx
		public ActionResult ParticipantesDx()
		{
			StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var str = reader.ReadToEndAsync().Result;
			var opts = JsonConvert.DeserializeObject<LoadOptions>(str);
			opts.PrimaryKey = new[] { "Id" };
			var data = JsonConvert.DeserializeObject<GenericModel>(opts.UserData);
			var items = _db.CursosUsuarios.Where(o => o.CursoId == data.id).OrderBy(o => o.Name).ToList();
			var loadResult = DataSourceLoader.Load(items, opts);
			return Ok(loadResult);
		}

		[HttpPost("encuestas-dx")] // /api/curso/dx => DevExtreme DataGrid Get
		public ActionResult EncuestasDx()
		{
			StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var str = reader.ReadToEndAsync().Result;
			var opts = JsonConvert.DeserializeObject<LoadOptions>(str);
			opts.PrimaryKey = new[] { "Id" };
			var data = JsonConvert.DeserializeObject<GenericModel>(opts.UserData);
			var items = _db.CursosEncuestas.Where(o => o.CursoId == data.id).OrderBy(o => o.Titulo).ToList();
			var loadResult = DataSourceLoader.Load(items, opts);
			return Ok(loadResult);
		}

		[HttpPost("dx")] // /api/curso/dx => DevExtreme DataGrid Get
		public ActionResult GetDx()
		{
			StreamReader reader = new StreamReader(Request.Body, Encoding.UTF8);
			var str = reader.ReadToEndAsync().Result;
			var opts = JsonConvert.DeserializeObject<LoadOptions>(str);
			dynamic data = JsonConvert.DeserializeObject<dynamic>(opts.UserData);
			opts.PrimaryKey = new[] { "Id" };
			var items = _db.Cursos.OrderBy(o => o.Nombre).ToList();
			var loadResult = DataSourceLoader.Load(items, opts);
			return Ok(loadResult);
		}
	}
}
