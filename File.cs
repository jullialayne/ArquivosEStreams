using static System.Console;
namespace file{
    class FileExample{
        static void Main(string[] args) {
            WriteLine("Digite o nome do arquivo: ");

            var nome = ReadLine();

            nome = LimparNome(nome);

            var path = Path.Combine(Environment.CurrentDirectory + $"\\{nome}.txt");

            CriarArquivo(path);

            WriteLine("Digite o enter para encerrar: ");
            ReadLine();

            var origem = Path.Combine(Environment.CurrentDirectory,"globo", "América do Sul","Brasil","brasil.txt");
            var destino = Path.Combine(Environment.CurrentDirectory,"globo", "América do Sul","Argentina","argentina.txt");

            CopiarArquivo(origem,destino);


            //var path = Path.Combine(Environment.CurrentDirectory,"globo");
            LerDiretorios(path);
            Console.WriteLine("Digite enter para finalizar...");
            Console.ReadLine();



            //var path = Path.Combine(Environment.CurrentDirectory,"globo");
            LerArquivos(path);
        }
        static void LerArquivos(String path){
            var arquivos = Directory.GetFiles(path,"*",SearchOption.AllDirectories);
            foreach(var arquivo in arquivos){
                var fileInfo=new FileInfo(arquivo);
                Console.WriteLine($"[Nome]:{fileInfo.Name}");
                Console.WriteLine($"[Tamanho]:{fileInfo.Length}");
                Console.WriteLine($"[Ultimo acesso]:{fileInfo.LastAccessTime}");
                Console.WriteLine($"[Pasta]:{fileInfo.DirectoryName}");
                Console.WriteLine("---------------------------------");
            }
        }

        static void LerDiretorios(string path){
            if(Directory.Exists(path)){
                var diretorios=Directory.GetDirectories(path,"*",SearchOption.AllDirectories);
                foreach(var dir in diretorios){
                    var dirInfo = new DirectoryInfo(dir);
                    Console.WriteLine($"[Nome]:{dirInfo.Name}");
                    Console.WriteLine($"[Raiz]:{dirInfo.Root}");
                    if(dirInfo.Parent != null)
                        Console.WriteLine($"[Pai]:{dirInfo.Parent.Name}");
                    Console.WriteLine("--------------------------------------------");
                }
            }else{
                Console.WriteLine("Diretorio não existe");
            }
        }

        static void CopiarArquivo(string pathOrigem, string pathDestino){
            if(!File.Exists(pathOrigem))
                Console.WriteLine("Arquivo de origem não existe");
                Console.ReadLine();
                return;

            if(File.Exists(pathDestino))
                Console.WriteLine("Arquivo já existe na pasta de destino");
                Console.ReadLine();
                return;

            File.Copy(pathOrigem,pathDestino);
        }

        //MoverArquivo(origem,destino);
        static void MoverArquivo(string pathOrigem, string pathDestino){
            if(!File.Exists(pathOrigem))
                Console.WriteLine("Arquivo de origem não existe");
                Console.ReadLine();
                return;

            if(File.Exists(pathDestino))
                Console.WriteLine("Arquivo já existe na pasta de destino");
                Console.ReadLine();
                return;

            File.Move(pathOrigem,pathDestino);
        }

        static string LimparNome(string nome){
            foreach(var @char in Path.GetInvalidFileNameChars()){
                nome = nome.Replace(@char,'-');
            }
            return nome;
        }
        static void CriarArquivo(string path){
            try{
                using var sw = File.CreateText(path);
                sw.WriteLine("Está é a linha 1 do arquivo");
                sw.WriteLine("Está é a linha 2 do arquivo");
                sw.WriteLine("Está é a linha 3 do arquivo");
            }catch(System.Exception){
                WriteLine("O nome do arquivo está inválido!");    }
        }



        static void CriarDiretoriosGlobo(){
            
            var path = Path.Combine(Environment.CurrentDirectory,"globo");
            if(!Directory.Exists(path)){
                var dirGlobo = Directory.CreateDirectory(path);
                var dirAmNorte = dirGlobo.CreateSubdirectory("América do Norte");
                var dirAmCentral = dirGlobo.CreateSubdirectory("América Central");
                var dirAmSul = dirGlobo.CreateSubdirectory("América do Sul");

                dirAmNorte.CreateSubdirectory("USA");
                dirAmNorte.CreateSubdirectory("México");
                dirAmNorte.CreateSubdirectory("Canada");

                dirAmCentral.CreateSubdirectory("Costa Rica");
                dirAmCentral.CreateSubdirectory("Panamá");

                dirAmSul.CreateSubdirectory("Brasil");
                dirAmSul.CreateSubdirectory("Argentina");
                dirAmSul.CreateSubdirectory("Paraguai");
            }
        }
    }
}