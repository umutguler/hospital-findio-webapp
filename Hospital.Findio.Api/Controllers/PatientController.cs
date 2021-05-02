using System.Threading.Tasks;
using Hospital.Findio.Api.Data;
using Hospital.Findio.Api.Dtos;
using Hospital.Findio.Api.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Hospital.Findio.Api.Controllers
{
	public class PatientController : BaseApiController
	{
		private readonly DataContext _context;
		public PatientController(DataContext context)
		{
			_context = context;
		}
		[HttpPost]
		public async Task<ActionResult> Create(Patient patient)
		{
			await _context.Patients.AddAsync(patient);
			await _context.SaveChangesAsync();
			return Ok();
		}
	}
}