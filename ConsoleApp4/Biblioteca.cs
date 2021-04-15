using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp4
{
    public class Biblioteca
    {
        public Utente UtenteLoggato { get; set; }
        public List<Utente> Utenti{ get; set; }
        public List<Documento> Documenti { get; set; }
        public List<Prestito> Prestiti{ get; set; }
        public Biblioteca()
        {
            Utenti = new List<Utente>();
            Documenti = new List<Documento>();
            Prestiti = new List<Prestito>();
            Utenti.Add(new Utente("valerio", "valdes", "3333333333", "test@gmail.com", "privata"));
        }
        private Documento SearchByKey(string value)
        {
            return Documenti.FirstOrDefault(d => d.Codice.Contains(value) || d.Titolo.Contains(value));
        }

        private List<Autore> GetAutori()
        {
            var result = new List<Autore>();
            do
            {
                Console.WriteLine("Inserisci il nome dell'autore o exit per uscire");
                var input = Console.ReadLine();
                if (input.ToLower() == "exit")
                    return result;
                Console.WriteLine("Inserisci il cognome dell'autore");
                string cognome = Console.ReadLine();
                var autore = new Autore(input, cognome);
                result.Add(autore);
            } while (true);
        }

        public void Login()
        {
            do
            {
                Console.WriteLine("inserisci username (email)");
                string email = Console.ReadLine();
                Console.WriteLine("inserisci password");
                string pass = Console.ReadLine();
                var utente = Utenti.FirstOrDefault(u => u.Email == email && u.Password == pass);
                if (utente == null)
                {
                    Console.WriteLine("Username o password errati");
                    continue;
                }
                UtenteLoggato = utente;
                Console.WriteLine("login effettuato con successo");
                return;
            } while (true);
        }

        public void CercaDocumento()
        {
            do
            {
                Console.WriteLine("Inserisci una chiave di ricerca:");
                var input = Console.ReadLine();
                var documentoTrovato = SearchByKey(input);
                if (documentoTrovato == null)
                {
                    Console.WriteLine("Documento non trovato. ");
                    continue;
                }
                Console.Write(documentoTrovato);
                if(documentoTrovato.Stato == Stato.Disponibile)
                {
                    Console.WriteLine("Il documento è disponibile, vuoi prenderlo in prestito? (S/N)");
                    var sceltaPrestito = Console.ReadLine();
                    if(sceltaPrestito.ToLower() == "s")
                    {
                        Console.WriteLine("per quanti giorni vuoi il documento?");
                        int durata = int.Parse(Console.ReadLine());
                        var prestito = new Prestito(durata, UtenteLoggato, documentoTrovato);
                        Prestiti.Add(prestito);

                        Console.WriteLine($"Il tuo prestito parte oggi {prestito.Inizio.ToString("dd/MM/yyyy")} e finisce fra {durata} giorni.");
                        Console.WriteLine($"Da restituire il {prestito.Fine.ToString("dd/MM/yyyy")}");
                    }
                }
                return;
            } while (true);

        }

        public void AggiungiDocumento()
        {
            Console.WriteLine("che documento vuoi inserire?");
            string tipoDocumento = Console.ReadLine().ToLower();
            Console.WriteLine("Inserisci codice");
            var codice = Console.ReadLine();
            Console.WriteLine("Inserisci titolo");
            var titolo = Console.ReadLine();
            Console.WriteLine("Inserisci anno");
            var anno = int.Parse(Console.ReadLine());
            Console.WriteLine("Inserisci genere");
            var settore = Console.ReadLine();
            List<Autore> autori = GetAutori();

            if (tipoDocumento == "libro")
            {
                Console.WriteLine("Inserisci il numero delle pagine");
                int numeroPagine = int.Parse(Console.ReadLine());
                var libro = new Libro(codice,titolo,anno,settore,autori, numeroPagine);
                Documenti.Add(libro);
            }
            else {
                Console.WriteLine("Inserisci la durata del dvd");
                int durata = int.Parse(Console.ReadLine());
                var dvd = new DVD(codice, titolo, anno, settore, autori, durata);
                Documenti.Add(dvd);
            }
        }

        

        public void AggiungiUtente()
        {
            Console.WriteLine("Inserisci nome utente");
            var nome = Console.ReadLine();
            Console.WriteLine("Inserisci cognome utente");
            var cognome = Console.ReadLine();
            Console.WriteLine("Inserisci telefono utente");
            var telefono = Console.ReadLine();
            Console.WriteLine("Inserisci email utente");
            var email = Console.ReadLine();
            Console.WriteLine("Inserisci pass utente");
            var pass = Console.ReadLine();
            var utente = new Utente(nome, cognome, telefono, email, pass);
            Utenti.Add(utente);
        }
    }
}
