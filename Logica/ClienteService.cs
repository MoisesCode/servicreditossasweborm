using System;
using System.Collections.Generic;
using Datos;
using Entity;
using System.Linq;

namespace Logica
{
    public class ClienteService
    {
        private readonly ClienteContext _context;

        public ClienteService(ClienteContext context)
        {
            _context = context;
        }

        public GuardarPersonaResponse Guardar(Cliente cliente)
        {
            try
            {
                var clienteBuscado = _context.Clientes.Find(cliente.Identificacion);
                if(clienteBuscado != null)
                {
                    string mensaje = $"El cliente con id: {clienteBuscado.Identificacion}, ya se encuentra registrado";
                    return new GuardarPersonaResponse(mensaje);
                }
                cliente.CalcularTotalAPagar();
                _context.Clientes.Add(cliente);
                _context.SaveChanges();
                return new GuardarPersonaResponse(cliente);
            }
            catch (Exception e)
            {
                return new GuardarPersonaResponse($"Error de la aplicacion: {e.Message}");
            }
        }

        public List<Cliente> Consultar()
        {
            List<Cliente> clientes = _context.Clientes.ToList();
            return clientes;
        }
    }

    public class GuardarPersonaResponse 
    {
        public bool Error { get; set; }
        public string Mensaje { get; set; }
        public Cliente cliente { get; set; }

        public GuardarPersonaResponse(Cliente cliente)
        {
            Error = false;
            Cliente cliente1 = cliente;
        }
        public GuardarPersonaResponse(string mensaje)
        {
            Error = true;
            Mensaje = mensaje;
        }
    }
}
