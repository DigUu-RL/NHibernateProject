using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NHibernateProject.Application.Interfaces;
using NHibernateProject.Domain.Request;

namespace NHibernateProject.Presentation.WebAPI.Controllers;

[ApiController]
[AllowAnonymous]
[Route("api/actor")]
public class ActorController : ControllerBase
{
	private readonly IApplicationActorService actorService;

	public ActorController(IApplicationActorService actorService)
	{
		this.actorService = actorService;
	}

	[HttpGet]
	public async Task<IActionResult> GetAll(int page = 1, int quantity = 10)
	{
		return Ok(await actorService.GetAllAsync(page, quantity));
	}

	[HttpGet("{id}")]
	public async Task<IActionResult> GetById(long id)
	{
		return Ok(await actorService.GetByIdAsync(id));
	}

	[HttpPost("create")]
	public async Task<IActionResult> Create(ActorRequest request)
	{
		await actorService.CreateAsync(request);
		return Ok();
	}

	[HttpPut("update")]
	public async Task<IActionResult> Update(ActorRequest request)
	{
		await actorService.UpdateAsync(request);
		return NoContent();
	}

	[HttpDelete("delete/{id}")]
	public async Task<IActionResult> Delete(long id)
	{
		await actorService.DeleteAsync(id);
		return NoContent();
	}
}
