using System.Speech.Synthesis;
using System.Speech.Recognition;
namespace voice_to_text_text_to_voice
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SpeechSynthesizer ss = new SpeechSynthesizer();
            ss.Volume = trackBar1.Value;
            ss.Speak(textBox1.Text);


        }

        private void button2_Click(object sender, EventArgs e)
        {
            SpeechRecognitionEngine s=new SpeechRecognitionEngine();
            Grammar words =new DictationGrammar();
            s.LoadGrammar(words);
            try
            {
                s.SetInputToDefaultAudioDevice();
                RecognitionResult result =s.Recognize();
                textBox1.Text = result.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                s.UnloadAllGrammars();
            }
            
        }
    }
}