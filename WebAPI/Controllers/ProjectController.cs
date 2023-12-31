﻿using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Dto;
using ProjectManagerApi.Extensions;
using ProjectManagerApi.Services;
using System.Security.Claims;

namespace ProjectManagerApi.Controllers
{
    [Route("api/project")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly IProjectService projectService;

        public ProjectController(IMapper mapper, IProjectService projectService)
        {
            this.mapper = mapper;
            this.projectService = projectService;
        }

        [HttpGet("get-all-projects")]
        public async Task<IActionResult> GetAllProjects()
        {
            return Ok(mapper.Map<List<ProjectGetDto>>(await projectService.GetAllProjects()));
        }

        [HttpPost]
        public async Task<IActionResult> CreateProject(ProjectDto projectDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = User.GetUserId();
                    var project = await projectService.CreateProject(userId, mapper.Map<Project>(projectDto), projectDto.TechnologiesList, projectDto.LanguagesList);
                    return Ok(mapper.Map<ProjectGetDto>(project));
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("{projectId}")]
        public async Task<IActionResult> UpdateProject(int projectId, ProjectUpdateDto projectUpdateDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int userId = User.GetUserId();
                    var project = await projectService.UpdateProject(userId, projectId, mapper.Map<Project>(projectUpdateDto));
                    return Ok(mapper.Map<ProjectGetDto>(project));
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("add-user")]
        public async Task<IActionResult> AddUserToProject(TeamUserDto addUserDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leaderId = User.GetUserId();
                    await projectService.AddUserToProject(addUserDto.ProjectId, leaderId, addUserDto.UserId, addUserDto.RoleId);
                    return Ok();
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPut("change-role")]
        public async Task<IActionResult> ChangeRole(TeamUserDto addUserDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leaderId = User.GetUserId();
                    await projectService.ChangeUserRole(addUserDto.ProjectId, leaderId, addUserDto.UserId, addUserDto.RoleId);
                    return Ok();
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("add-status")]
        public async Task<IActionResult> AddStatus(ProjectStatusDto projectStatusDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var leaderId = User.GetUserId();
                    await projectService.SetProjectStatus(projectStatusDto.ProjectId, leaderId, projectStatusDto.StatusId);
                    return Ok();
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpGet("projects-with-private-recruitment")]
        public async Task<IActionResult> GetAllProjectWithPrivateRecruitment()
        {
            return Ok(mapper.Map<List<ProjectGetDto>>(await projectService.GetAllProjectWithPrivateRecruitment()));
        }

        [HttpGet("serach-by-lang/{langId}")]
        public async Task<IActionResult> GetProjectsByLanguage(int langId)
        {
            return Ok(mapper.Map<List<ProjectGetDto>>(await projectService.GetProjectsByLanguage(langId)));
        }

        [HttpGet("search-by-tech/{techId}")]
        public async Task<IActionResult> GetProjectsByTech(int techId)
        {
            return Ok(mapper.Map<List<ProjectGetDto>>(await projectService.GetProjectsByTech(techId)));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProject(int id)
        {
            try
            {
                return Ok(mapper.Map<ProjectGetDto>(await projectService.GetProjectById(id)));
            }
            catch (InvalidItemException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}/applications")]
        public async Task<IActionResult> GetProjectApplications(int id)
        {
            try
            {
                var userId = User.GetUserId();
                return Ok(mapper.Map<List<UserGetDto>>(await projectService.GetApplicants(userId, id)));
            }
            catch (InvalidItemException e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("apply")]
        public async Task<IActionResult> ApplyUserToProject(ApplyToProjectDto applyToProjectDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.GetUserId();
                    await projectService.ApplyUserToProject(userId, applyToProjectDto.ProjectId);
                    return Ok();
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }

        [HttpPost("set-repository")]
        public async Task<IActionResult> SetRepository(RepositoryDto setRepositoryDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var userId = User.GetUserId();
                    await projectService.SetRepositoryUrl(userId, setRepositoryDto.ProjectId, setRepositoryDto.RepositoryUrl);
                    return Ok();
                }
                catch (InvalidItemException e)
                {
                    return BadRequest(e.Message);
                }
            }

            return BadRequest(ModelState);
        }
    }
}
