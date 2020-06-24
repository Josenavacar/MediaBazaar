using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;

namespace MediaBazaarSystem
{
    public class EmailHelper
    {
        /**
         * Method to send staff an email
         */
        public void SendScheduleEmail( String body, String to )
        {
            String from = "media_bazaar_nl@hotmail.com";
            String password = "mediaBazaarNL";

            if( !string.IsNullOrWhiteSpace( body ) )
            {
                MimeMessage message = new MimeMessage();
                message.From.Add( new MailboxAddress( "HR manager", from ) );
                message.To.Add( new MailboxAddress( "Employee ", "440569@student.fontys.nl" ) ); //to
                message.Subject = "Shift information";

                message.Body = new TextPart( "plain" )
                {
                    Text = body
                };

                using( var client = new SmtpClient() )
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    //client.ServerCertificateValidationCallback = ( s, c, h, error ) => true;

                    // Enter mail requirements. In this case we're using outlook with code 587
                    client.Connect( "smtp.office365.com", 587, false );

                    // Note: if the SMTP server requires authentication
                    client.Authenticate( from, password ); //

                    // Send email then disconnect
                    client.Send( message );
                    client.Disconnect( true );
                }
            }
        }
    }
}
