using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TextInfoWebApi.CustomSessionFilters;
using TextOperationServices.Interfaces;
using TransferObjects;

namespace TextInfoWebApi.Controllers
{

    [RoutePrefix("text-infos")]
    [CheckTokenAuthorization]
    public class TextActionsController : ApiController
    {
        private ITextService _textService;

        public TextActionsController(ITextService textService)
        {
            _textService = textService;
        }

        [HttpPost, Route("count-words")]
        public string CountWords(SimpleDto dto)
        {
            string result = _textService.ReturnNumberOfWordsInText(dto.Text);
            return _textService.ReturnNumberOfWordsInText(dto.Text);
        }

        [HttpPost, Route("test")]
        public string Test()
        {
            return "test";
        }

        [HttpGet, Route("status")]
        public string HealthCheck()
        {
            return "ok";
        }
    }
}
