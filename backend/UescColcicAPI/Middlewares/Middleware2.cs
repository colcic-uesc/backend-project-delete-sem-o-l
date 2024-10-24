using System;

namespace UescColcicAPI.Middlewares;

public class Middleware2
{
   private readonly RequestDelegate _next;
   
   public Middleware2(RequestDelegate next)
   {
      _next = next;
   }
   
   public async Task InvokeAsync(HttpContext context)
   {
      // Adiciona os cabeçalhos na resposta
      context.Response.Headers.Append("X-APP-NAME", "Dellícia");
      context.Response.Headers.Append("X-APP-API-VERSION", "0.1");

      // Chama o próximo middleware no pipeline
      await _next(context);
   }
}