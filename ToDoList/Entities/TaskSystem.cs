using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoList.Entities
{
    public class TaskSystem
    {
        public List<Tasks> Tarefas { get; set; } = new List<Tasks>();

        public TaskSystem()
        {

        }
      
        public void ViewTask()
        {
            
            foreach (var task in Tarefas)
            {
                //Fazendo uma interpolação
                Console.Clear();
                Console.WriteLine("╔═════════════════════╗");
                Console.WriteLine("║     VISUALIZAR      ║");
                Console.WriteLine("╚═════════════════════╝");
                Console.WriteLine("Os dados de sua tarefa são: ");
                Console.WriteLine();
                Console.WriteLine($"ID: {task.TaskId},  Título: {task.Title}, Descrição: {task.Description}, Data de criação: {task.CreationDate} ");
            }
            Console.WriteLine();
            Console.WriteLine("Deseja voltar para o menu principal (s/n)?");
            char resposta = char.Parse(Console.ReadLine().ToLower());
            if(resposta == 's')
            {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("VOLTANDO AO MENU PRINCIPAL! ");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                MenuPrincipal();

            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("FECHANDO O PROGRAMA! ");
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
            

        }
        public void DeleteTask()
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════╗");
            Console.WriteLine("║        DELETAR      ║");
            Console.WriteLine("╚═════════════════════╝");
            Console.WriteLine("Tarefas existentes "); 

            // a cada uma tarefa (variável tarefa) na minha lista Tarefas (lista) eu vou fazer tal...
            foreach (var tarefa in Tarefas)
            {
                Console.WriteLine($"Id: {tarefa.TaskId}");
                Console.WriteLine($"Título: {tarefa.Title}");

            }
            Console.WriteLine();
            Console.WriteLine("Digite o ID que deseja excluir: ");
            int id = int.Parse(Console.ReadLine()); 
            var tarefaSelecionada = Tarefas.First(t => t.TaskId == id); 
            Tarefas.Remove(tarefaSelecionada);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("TAREFA DELETADA COM SUCESSO! ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
           
            MenuPrincipal();
        }

        public void MenuPrincipal()
        {
            
            Console.Clear();
            Console.WriteLine("╔═════════════════════╗");
            Console.WriteLine("║     TO DO LIST      ║");
            Console.WriteLine("╠═════════════════════╣");
            Console.WriteLine("║ 1-ADICIONAR         ║");
            Console.WriteLine("║ 2-VISUALIZAR        ║");
            Console.WriteLine("║ 3-REMOVER           ║");
            Console.WriteLine("║ 0-FECHAR            ║");
            Console.WriteLine("╚═════════════════════╝");
            int opMenu = MostrarOpcaoMenu();


            switch (opMenu)
            {
                case 1:
                    CadastrarTarefa();
                    break;
                case 2:
                    ViewTask();
                    break;
                case 3:
                    DeleteTask();
                    break;
                default:
                    Console.WriteLine("Menu inválido, digite novamente.");
                    break;
            }


        }

        public int MostrarOpcaoMenu()
        {
            Console.Write("\nEscolha uma opção: ");
            return int.Parse(Console.ReadLine());
        }

        public void CadastrarTarefa()
        {
            Console.Clear();
            Console.WriteLine("╔═════════════════════╗");
            Console.WriteLine("║       CADASTRO      ║");
            Console.WriteLine("╚═════════════════════╝");
            Console.WriteLine();
            Console.Write("O que deseja cadastrar hoje? ");
            Console.WriteLine();
            int Id = GerarId();
            Console.Write("Título: ");
            string title = Console.ReadLine();
            Console.Write("Description: ");
            string desc = Console.ReadLine();
            Console.Write("Data de criação: ");
            DateTime date = DateTime.Parse(Console.ReadLine());
            Tarefas.Add(new Tasks(Id, title, desc, date));
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Tarefa cadastrada com sucesso! ");
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(1000);
            MenuPrincipal();
        }
        public int GerarId()
        {
            if(Tarefas.Count > 0)
            {
                int tarefaId = Tarefas.Last().TaskId;
                tarefaId++;
                return tarefaId;
            }
            else
            {
                return 1; 
            }
        }

    }
}
