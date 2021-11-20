using Microsoft.AspNetCore.Mvc;
using NorthWind.Entities.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace NorthWind.WebExceptionPresenters.ExceptionHandlers
{
    public class ExceptionService
    {
        // Diccionario de parejas Excepción-Manejador 
        readonly Dictionary<Type, Type> ExceptionHandlers = new();
        public ExceptionService()
        {
            Type[] Types =
                Assembly.GetExecutingAssembly().GetTypes();
            foreach (Type T in Types)
            {
                // Obtener las clases que implementan IExceptionHandler
                var Handlers = T.GetInterfaces()
                    .Where(i =>
                        i.IsGenericType &&
                        i.GetGenericTypeDefinition() ==
                            typeof(IExceptionHandler<>));

                // Agregar los manejadores al diccionario.
                // Asumimos que un tipo puede manejar varas excepciones.
                foreach (Type I in Handlers)
                {
                    var ExceptionType = I.GetGenericArguments()[0];
                    // Solo se registra un manejador por excepción
                    ExceptionHandlers.TryAdd(ExceptionType, T);
                }
            }
        }
        public ValueTask<ProblemDetails> Handle(Exception exception)
        {
            ValueTask<ProblemDetails> Result;
            if (ExceptionHandlers.TryGetValue(exception.GetType(),
                out Type HandlerType))
            {
                var Handler = Activator.CreateInstance(HandlerType);
                Result =
                    (ValueTask<ProblemDetails>)HandlerType.GetMethod("Handle")
                    .Invoke(Handler, new object[] { exception });
            }
            else
            {
                Result = new GeneralExceptionHandler()
                    .Handle(new GeneralException(
                        "Ha ocurrido un error al procesar la respuesta.",
                        "Consulte al administrador."));
            }
            return Result;
        }
    }

}
