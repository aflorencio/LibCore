using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibCore
{
    public interface IPresupuesto
    {
        IFlow IFlow { get; set; }
        ITicket ITicket { get; set; }
        IQueueNotification IQueueNotification { get; set; }
        IContacto IContacto { get; set; }

        void CreatePresupuesto();
        /// <summary>
        /// Agregara un nuevo ID de rastreo
        /// </summary>
        /// <remarks>- Si se añade un nuevo ID de rasteo al presupuesto debemos indicar en el booleano que el presupuesto modificado de la base de datos sea TRUE.</remarks>
        void AddRastreoServiceToPresupuesto();
        /// <summary>
        /// Modifica un presupuesto
        /// </summary>
        /// <remarks>- Si el presupuesto se modifica este enviara a la base de datos boleano de presupuesto modificado 1. De esta forma se sabra que la generacion que se creo no esta actualizada y pondremos el cliente firmado como 0</remarks>
        void UpdatePresupuesto();
        /// <summary>
        /// Genera un presupuesto si presupuesto modificado está en true
        /// </summary>
        /// <remarks>
        /// - Si presupuestoModificado de la base de datos esta en true como que se ha modificado el presupuesto o se ha creado entonces la accion de Generar presupuesto estara disponible.
        /// - Generará un PDF con el documento del presupuesto y presupuesto modificado de la base de datos lo pondra como false para que no permita generar nuevos PDFs ya que no hay modificaciones en el presupuesto.
        /// </remarks>
        void GenerarPresupuesto();
        /// <summary>
        /// Insertara en el bool como que el presupuesto ha sido firmado
        /// </summary>
        /// <remarks>- Si presupuesto ha sido firmado y o aceptado entonces nos pedirá que subamos el PDF firmado al sistema. Este llamara al servicio de DocumentoService y lo almacenará.</remarks>
        void FirmarPresupuesto();
        /// <summary>
        /// Es un metodo sobrecaergado este lo insertara el otro lo vera solo
        /// </summary>
        void FirmarPresupuesto(string id);

        /// <summary>
        /// Borra un presupuesto solo para adminsitradores
        /// </summary>
        void DeletePresupuesto();
        /// <summary>
        /// Desecha el presupuesto y con que motivo lo ha desechado.
        /// </summary>
        void DesecharPresupuesto();
    }
}