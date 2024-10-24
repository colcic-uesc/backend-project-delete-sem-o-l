using Microsoft.AspNetCore.Http;
using System;
using System.Diagnostics;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;

namespace UescColcicAPI.Middlewares
{
   public class Middleware1
   {
      private readonly RequestDelegate _next;

      public Middleware1(RequestDelegate next)
      {
         _next = next;
      }

      public async Task Invoke(HttpContext context)
      {
         var stopwatch = Stopwatch.StartNew();

         // Captura do IP do Cliente
         var clientIp = context.Connection.RemoteIpAddress?.ToString();

         // Verifica se há Token JWT
         var hasJwtToken = context.Request.Headers.ContainsKey("Authorization");

         // Data e Hora da Requisição
         var requestTime = DateTime.UtcNow;

         // Método e URL da Requisição
         var requestMethod = context.Request.Method;
         var requestUrl = context.Request.Path;

         // Executa o próximo middleware no pipeline
         await _next(context);

         // Tempo total do processamento
         stopwatch.Stop();
         var totalProcessingTime = stopwatch.ElapsedMilliseconds;

         // Criação do log
         var logEntry = new
         {
            ClientIp = clientIp,
            HasJwtToken = hasJwtToken,
            RequestTime = requestTime,
            RequestMethod = requestMethod,
            RequestUrl = requestUrl,
            ProcessingTimeMs = totalProcessingTime
         };

         // Salvar o log em arquivo
         await SaveLogToFileAsync(logEntry);
      }

      private async Task SaveLogToFileAsync(object logEntry)
      {
         var logPath = Path.Combine(AppContext.BaseDirectory, "logs", "requests-log.txt");

         // Cria o diretório, se não existir
         var logDirectory = Path.GetDirectoryName(logPath);
         if (!Directory.Exists(logDirectory))
         {
            Directory.CreateDirectory(logDirectory);
         }

         // Salva o log em formato JSON
         await File.AppendAllTextAsync(logPath, JsonSerializer.Serialize(logEntry) + Environment.NewLine);
      }
   }
}