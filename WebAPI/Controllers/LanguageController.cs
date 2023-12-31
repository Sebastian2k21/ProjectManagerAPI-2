﻿using ApplicationCore.Exceptions;
using ApplicationCore.Interfaces;
using ApplicationCore.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using ProjectManagerApi.Dto;
using ProjectManagerApi.Services;

namespace ProjectManagerApi.Controllers
{
    [Route("api/language")]
    [ApiController]
    public class LanguageController : ControllerBase
    {
        private readonly ILanguageService languageService;
        private readonly IMapper mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            this.languageService = languageService;
            this.mapper = mapper;   
        }

        [HttpGet("get-all-languages")]
        public async Task<IActionResult> GetAllLanguages()
        {
            return Ok(mapper.Map<List<LanguageDto>>(await languageService.GetAllLanguages()));
        }

        [HttpPost("add-new-language")]
        public async Task<IActionResult> AddNewLanguage(AddLanguageDto language)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    var lang = await languageService.AddNewLanguage(mapper.Map<Language>(language));
                    return Ok(mapper.Map<Language>(lang));
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
