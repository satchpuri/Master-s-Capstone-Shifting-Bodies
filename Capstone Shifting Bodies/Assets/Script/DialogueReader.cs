using System.IO;

public class DialogueReader {

  
    void readTextFile(string file_path)
    {
        StreamReader inp_stm = new StreamReader(file_path);

        while (!inp_stm.EndOfStream)
        {
            string inp_ln = inp_stm.ReadLine();
            // do stuff with input 
        }

        inp_stm.Close();
    }
}
