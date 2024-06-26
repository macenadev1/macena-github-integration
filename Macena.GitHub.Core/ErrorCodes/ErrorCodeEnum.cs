using System.ComponentModel;

namespace Macena.GitHub.Core.ErrorCodes
{
    public enum ErrorCodeEnum
    {
        /// <summary>
        /// Invalid Code.
        /// </summary>
        [Description("Indefinido")]
        Undefined = 0,

        /// <summary>
        /// Invalid Code.
        /// </summary>
        [Description("Campo nulo ou vazio")]
        FieldIsNullOrEmpty = 1,

        /// <summary>
        /// Communication error with the integrator.
        /// </summary>
        [Description("Erro de comunicação com o integrador")]
        CommunicationError = 2,

        /// <summary>
        /// Internal server error.
        /// </summary>
        [Description("Erro do Servidor Interno")]
        UnexpectedError = 999
    }
}