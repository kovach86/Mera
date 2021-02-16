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
        private readonly ITextService _textService;

        public TextActionsController(ITextService textService)
        {
            _textService = textService;
        }

        [HttpPost, Route("count-words")]
        public string CountWords(SimpleDto dto)
        {
            string result = _textService.ReturnNumberOfWordsInText(dto.Text);
            return result;
        }
         
    }
}
