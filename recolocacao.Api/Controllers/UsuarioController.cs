using System;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using recolocacao.Api.services;
using recolocacao.Dominio.Commands;
using recolocacao.Dominio.Entidades;
using recolocacao.Dominio.Repositories;

namespace recolocacao.Api.Controllers
{
    [ApiController]
    [Route("v1/usuarios")]
    public class UsuarioController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public ResponseCommandResult Post(
            [FromBody]Dominio.Commands.Usuario.CriarUsuarioCommand cmd ,
            [FromServices]Dominio.Handlers.Usuario.CriarUsuarioHandler hdl
            )
        {
            try
            {
                var response = (ResponseCommandResult)hdl.Handle(cmd);

                if(response.Valid)
                    SendMailVerificationAccount(cmd.Email);

                return response;
            }
            catch (System.Exception ex)
            {
                return new ResponseCommandResult(false, ex.Message, ex);
            }

        }

        private void SendMailVerificationAccount(string email)
        {
            var sbBody = new StringBuilder();

            sbBody.AppendFormat("<html>");
            sbBody.AppendFormat("   <header>");
            sbBody.AppendFormat("       <title>");
            sbBody.AppendFormat("               Recolocação Profissional");
            sbBody.AppendFormat("       </title>");
            sbBody.AppendFormat("   </header>");
            sbBody.AppendFormat("   <body>");
            sbBody.AppendFormat("       <h1>Seu código de verificação é:</h1><h3>999999</h3>");
            sbBody.AppendFormat("   </body>");
            sbBody.AppendFormat("</html>");

            var mail = new SendMail();
            mail.Send(
                        email, 
                        "Verificação de Conta - Recolocacao Profissional",
                        sbBody.ToString(),
                        true
                        );
        }
    }
}