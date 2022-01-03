using NixPDC;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Interactions;

namespace botmap
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void btn_iniciar_Click(object sender, EventArgs e)
        {
            //Entra na steam 
            IWebDriver driver = SeleniumMetodos.criaDriver(Constantes.headless);
            SeleniumMetodos.navegarPara(driver, "https://store.steampowered.com/login/?redir=&redir_ssl=1&snr=1_4_661__global-header");
            

            int i = 0;


            do
            {
                FuncoesUteis.pausa(1000);//pede para fazer login e só continua o código depois do OK
                MessageBox.Show("Faça login e DEPOIS que logar aperte o botão OK", "Instrução", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

                try
                {
                    SeleniumMetodos.clickPorClasse(driver, "login_btn");//clica no botão de login para verificar se ja saiu da tela de login (se não tem botão de login, não está na tela de login! GE-NI-AL kkk)
                    
                    
                }

                catch (Exception ex)
                {

                    if (ex is OpenQA.Selenium.NoSuchElementException)//caso não esteja na tela de login, a falta do botão vai causar um erro que vai somar +1 no contador e sair do laço
                    {
                        i++;
                        

                    }
                    else
                    {
                        
                    }



                }

            } while (i == 0);


            


            int tempo = 1000;

            SeleniumMetodos.navegarPara(driver, "https://store.steampowered.com/explore/");//vai para a página da lista de descobrimento
            FuncoesUteis.pausa(tempo);

            try
            {
                //tentativas falhas de clicar no botão gigantesco no meio da página
                //SeleniumMetodos.clickPorClasse(driver, "discovery_queue_overlay");
                //SeleniumMetodos.clickPorXPATH(driver, "/html/body/div[1]/div[7]/div[5]/div[1]/div[3]/div/div[1]/div[2]/div[2]/span");
                //SeleniumMetodos.clickPorId(driver, "refresh_queue_btn");


                SeleniumMetodos.clickPorId(driver, "discovery_queue_start_link");//inicia a lista


            }

            catch (Exception ex2)
            {
                if (ex2 is OpenQA.Selenium.NoSuchElementException)
                {
                    
                    //SeleniumMetodos.clickPorClasse(driver, "discovery_queue_overlay");
                    //SeleniumMetodos.clickPorXPATH(driver, "/html/body/div[1]/div[7]/div[5]/div[1]/div[3]/div/div[1]/div[3]/a/div/div");
                    SeleniumMetodos.clickPorId(driver, "discovery_queue_start_link"); //parte inutil do código, se ele não achar o botão ele vai avisar que a lista ja terminou de um jeito ou de outro

                }
                else
                {

                }
            }
            

            FuncoesUteis.pausa(tempo);
            

            int j = 0;
            do
            {

                try
                {
                    SeleniumMetodos.clickPorClasse(driver, "next_in_queue_content");// depois de iniciada vai passando a lista pra frente

                }

                catch (Exception ex2)
                {
                    if (ex2 is OpenQA.Selenium.NoSuchElementException)
                    {
                        //se não tem botão de next, a lista ja acabou (proteção contra listas que foram vistas e tem menos de 12 jogos)
                        MessageBox.Show("Você ja viu sua lista inteira hoje!", "Prompt", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                        j = j + 100;
                    }
                    else
                    {

                    }
                }

                j++;
                FuncoesUteis.pausa(tempo);




            } while (j  < 12);







            if (j < 100)//para evitar que o mesmo aviso apareça duas vezes, essa execução é a execução se viu a lista toda, a de cima junto com o else abaixo é a execução de listas com menos de 12 jogos
            {
                
                MessageBox.Show("Você ja viu sua lista inteira hoje!", "Instrução", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                MessageBox.Show("Aperte OK para fechar o programa\nIsso vai fechar o navegador que abriu", "Instrução", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                SeleniumMetodos.fecharDriver(driver);
            }

            else

            {
                
                MessageBox.Show("Aperte OK para fechar o programa", "Instrução", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
                SeleniumMetodos.fecharDriver(driver);

            }


            
























        }

    private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lbl_regiao_Click(object sender, EventArgs e)
        {

        }

        private void txt_publicoAlvo_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        //feito por: Arthur Quintanilha, vulgo Paraíba BDK.

    }

    
}
