namespace file{
    class StreamsExample{
        static void Main(string[] args) {
            var path = @"globo";
            using var fsw = new FileSystemWatcher(path);

            fsw.Created +=OnCreated;
            fsw.Renamed +=OnRenamead;
            fsw.Deleted +=OnDeleted;

            fsw.EnableRaisingEvents = true;
            fsw.IncludeSubdirectories = true;

            Console.WriteLine($"Monitorando eventos na pasta {path}");
            Console.WriteLine("Pressione [enter] para finalizar...");
            Console.ReadLine();
       
            void OnCreated(object sender, FileSystemEventArgs e){
                Console.WriteLine($"Foi criado o arquivo {e.Name}");
            }   
            void OnRenamead(object sender, RenamedEventArgs e){
                Console.WriteLine($"O arquivo {e.OldName} foi renomeado para {e.Name}");
            }
            void OnDeleted(object sender, FileSystemEventArgs e){
                Console.WriteLine($"Foi excluido o arquivo {e.Name}");
            } 
        }
    }
}