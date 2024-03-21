using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Text.RegularExpressions;
using System.Data;
using System.Security.Cryptography;
using System;

namespace DIG_RT_MonitorPedidosErros.Repositories.Script
{
    internal class OrderScripts
    {
        //(1 consultar por caso de erro )
        internal static string SelectPedidosErros =>
            @"
                
               SELECT
               pe.error,
               pe.message,
               pe.date_created,
               pe.processing_type_id,
               pe.id,
               pe.order_number
            FROM

               processing_error pe
           JOIN
              processing_type pt ON pe.processing_type_id = pt.id
          WHERE
               pe.processing_type_id = 201

              AND pe.error = 1

              AND pe.message = 'FILA INSERIDA COM SUCESSO';
                ";

        //( 2- busa por pedido e data )
        internal static string SelectDataPedidos =>
           @"
              SELECT
              pe.date_created,
              pe.id,
              pe.order_number
          FROM

              processing_error pe
          JOIN
              processing_type pt ON pe.processing_type_id = pt.id
        WHERE
              pe.processing_type_id = 201

              AND pe.error = 1

              AND pe.message = 'FILA INSERIDA COM SUCESSO';
                ";

        // (3- Consultar a jornada de pedido por data e pedido )
        internal static string SelectQuantidadesErros =>
           @"
               SELECT
               COALESCE(to_char(pe.date_created, 'YYYY-MM-DD'), 'Total') AS date_created,
               pe.order_number,
               COUNT(*) AS error_count
        FROM
            processing_error pe
        LEFT JOIN
         processing_error  o ON pe.order_number = o.order_number
        WHERE
          pe.processing_type_id = 201 
            AND pe.error > 1 
            AND EXTRACT(YEAR FROM pe.date_created) = 2024 
            AND EXTRACT(MONTH FROM pe.date_created) = 2
        GROUP BY
            to_char(pe.date_created, 'YYYY-MM-DD'),
            pe.order_number
        ORDER BY
            date_created DESC;

                ";

    }



}
