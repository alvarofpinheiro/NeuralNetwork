using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections;
using System.IO;
using System.Text;

public partial class _Default : System.Web.UI.Page
{
    private static ArrayList System_out_println = new ArrayList();
    private static int nDecimais = 0;

    private static double[] vies1;
    private static double[] vies2;

    private static double[] antigodeltabs1;
    private static double[] antigodeltabs2;
    private static double[] deltabs1;
    private static double[] deltabs2;

    private static double[,] pesos1;
    private static double[,] pesos2;

    private static double[,] antigodeltapesos1;
    private static double[,] antigodeltapesos2;

    private static double[,] deltapesos1;
    private static double[,] deltapesos2;

    private static double[] net1;
    private static double[,] net2;
    private static double[,] netout;
    private static double[,] erro1;
    private static double[,] erro2;

    private static double[] sensibilidade1;

    private static double[] fnet1;

    private static double[,] entradas;

    private static double[,] saidas;

    //Atributo que indica o número de entradas.
    private static int numEntradas;

    //Atributo que indica o número de camadas escondidas.
    private static int numEscondidas;

    //Atributo que indica o número de saí­das.
    private static int numSaidas;

    //Atributo que indica a quantidade de épocas.
    private static int ciclos;

    //Atributo que indica o  ciclo atual.
    private static int cicloAtual;

    //Atributo que indica o número de treinamentos.
    private static int numTreinamentos;

    //Atributo que indica o valor de Lcoef (taxa de aprendizagem).
    private static double alfa;

    //Atributo que indica o valor de Motum (Momentum).
    private static double beta;

    //Atributo que indica o valor da semente do gerador de números aleatórios.
    private static long semente;

    //Retorna o valor de semente.
    public static long getSemente()
    {
        return semente;
    }

    //Atribui o valor de semente.
    public static void setSemente(long value)
    {
        semente = value;
    }

    //Retorna o valor de beta.
    public static double getBeta()
    {
        return beta;
    }

    //Atribui o valor de beta.
    public static void setBeta(double value)
    {
        beta = value;
    }

    //Retorna o valor de alfa.
    public static double getAlfa()
    {
        return alfa;
    }

    //Atribui o valor de alfa
    public static void setAlfa(double value)
    {
        alfa = value;
    }

    //Retorna o número de exemplos de treinamento.
    public static int getnumTreinamentos()
    {
        return numTreinamentos;
    }

    //Atribui o número de exemplos de treinamento.
    public static void setnumTreinamentos(int value)
    {
        numTreinamentos = value;
    }

    //Retorna o número de ciclos.
    public static int getCiclos()
    {
        return ciclos;
    }

    //Atribui o número de ciclos.
    public static int getCicloAtual()
    {
        return cicloAtual;
    }

    //Atribui o ciclo atual.
    public static void setCicloAtual(int value)
    {
        cicloAtual = value;
    }

    //Atribui o ciclo atual.
    public static void setCiclos(int value)
    {
        ciclos = value;
    }

    //Retorna o número de saí­das.
    public static int getnumSaidas()
    {
        return numSaidas;
    }

    //Atribui o número de saí­das.
    public static void setnumSaidas(int value)
    {
        numSaidas = value;

        //inicializa os vetores para vies2 e prdlbs2
        vies2 = new double[getnumSaidas()];
        antigodeltabs2 = new double[getnumSaidas()];
        deltabs2 = new double[getnumSaidas()];
    }

    //Retorna o número de entradas.
    public static int getnumEntradas()
    {
        return numEntradas;
    }

    //Atribui o número de entradas.
    public static void setnumEntradas(int value)
    {
        numEntradas = value;
    }

    //Retorna o número de neurônios escondidos.
    public static int getnumEscondidas()
    {
        return numEscondidas;
    }

    //Atribui o número de neurônios escondidos.
    public static void setnumEscondidas(int value)
    {
        numEscondidas = value;

        //Inicializa o vetor para vies1, netin1, sum1, prdlbs1, delbs1.
        vies1 = new double[getnumEscondidas()];
        net1 = new double[getnumEscondidas()];
        sensibilidade1 = new double[getnumEscondidas()];
        fnet1 = new double[getnumEscondidas()];
        antigodeltabs1 = new double[getnumEscondidas()];
        deltabs1 = new double[getnumEscondidas()];
    }

    //Atribui o valor do vies1 no índice indicado.
    public static void setVies1(int index, double value)
    {
        vies1[index] = value;
    }

    //Retorna o valor do vies1 no índice indicado.
    public static double getVies1(int index)
    {
        return vies1[index];
    }

    //Atribui o valor do vies2 no í­ndice indicado.
    public static double getVies2(int index)
    {
        return vies2[index];
    }

    //Atribui o valor do netin1 no í­ndice indicado.
    public static void setNet1(int index, double value)
    {
        net1[index] = value;
    }

    //Retorna o valor do netin1 no índice indicado.
    public static double getNet1(int index)
    {
        return net1[index];
    }

    //Atribui o valor do sum1 no índice indicado.
    public static void setSensibilidade1(int index, double value)
    {
        sensibilidade1[index] = value;
    }

    //Retorna o valor da sensibilidade no índice indicado.
    public static double getSensibilidade1(int index)
    {
        return sensibilidade1[index];
    }

    //Retorna o valor do fnet1 no índice indicado.
    public static double getFnet1(int index)
    {
        return fnet1[index];
    }

    //Atribui o valor do fnet1 no índice indicado.
    public static void setFnet1(int index, double value)
    {
        fnet1[index] = value;
    }

    //Retorna o valor do Antigodeltabs2 no índice indicado.
    public static double getAntigodeltabs2(int index)
    {
        return antigodeltabs2[index];
    }

    //Atribui o valor do Antigodeltabs1 no índice indicado.
    public static void setAntigodeltabs1(int index, double value)
    {
        antigodeltabs1[index] = value;
    }

    //Atribui o valor do Antigodeltabs2 no índice indicado.
    public static void setAntigodeltabs2(int index, double value)
    {
        antigodeltabs2[index] = value;
    }

    //Retorna o valor do Antigodeltabs1 no índice indicado.
    public static double getAntigodeltabs1(int index)
    {
        return antigodeltabs1[index];
    }

    //Atribui o valor do delbs1 no índice indicado.
    public static void setDeltabs1(int index, double value)
    {
        deltabs1[index] = value;
    }

    //Retorna o valor do deltabs1 no índice indicado.
    public static double getDeltabs1(int index)
    {
        return deltabs1[index];
    }

    //Atribui o valor do deltabs2 no índice indicado.
    public static void setDeltabs2(int index, double value)
    {
        deltabs2[index] = value;
    }

    //Retorna o valor do deltabs2 no índice indicado.
    public static double getDeltabs2(int index)
    {
        return deltabs2[index];
    }

    //Atribui o valor do vies2 no índice indicado.
    public static void setVies2(int index, double value)
    {
        vies2[index] = value;
    }

    //Retorna o valor do Pesos1
    public static double getPesos1(int row, int col)
    {
        return Math.Round(pesos1[row, col], nDecimais);
    }

    //Atribui o valor de Pesos1.
    public static void setPesos1(int row, int col, double value)
    {
        pesos1[row, col] = value;
    }

    //Retorna o valor do Pesos2
    public static double getPesos2(int row, int col)
    {
        return Math.Round(pesos2[row, col], nDecimais);
    }

    //Atribui o valor de Pesos2.
    public static void setPesos2(int row, int col, double value)
    {
        pesos2[row, col] = value;
    }

    //Retorna o valor do Antigodeltapesos1
    public static double getAntigodeltapesos1(int row, int col)
    {
        return Math.Round(antigodeltapesos1[row, col], nDecimais);
    }

    //Atribui o valor de Antigodeltapesos2.
    public static void setAntigodeltapesos2(int row, int col, double value)
    {
        antigodeltapesos2[row, col] = value;
    }

    //Retorna o valor do Antigodeltapesos2
    public static double getAntigodeltapesos2(int row, int col)
    {
        return Math.Round(antigodeltapesos2[row, col], nDecimais);
    }

    //Atribui o valor de Antigodeltapesos1.
    public static void setAntigodeltapesos1(int row, int col, double value)
    {
        antigodeltapesos1[row, col] = value;
    }

    //Retorna o valor do Deltapesos1
    public static double getDeltapesos1(int row, int col)
    {
        return Math.Round(deltapesos1[row, col], nDecimais);
    }

    //Atribui o valor de Deltapesos1.
    public static void setDeltapesos1(int row, int col, double value)
    {
        deltapesos1[row, col] = value;
    }

    //Retorna o valor do Deltapesos2
    public static double getDeltapesos2(int row, int col)
    {
        return Math.Round(deltapesos2[row, col], nDecimais);
    }

    //Atribui o valor de Deltapesos2.
    public static void setDeltapesos2(int row, int col, double value)
    {
        deltapesos2[row, col] = value;
    }

    //Inicializa o valor da matriz Pesos1.
    public static void initPesos1(int row, int col)
    {
        pesos1 = new double[row, col];
    }

    //Retorna o valor do Net2
    public static double getNet2(int row, int col)
    {
        return net2[row, col];
    }

    //Atribui o valor de Net2.
    public static void setNet2(int row, int col, double value)
    {
        net2[row, col] = value;
    }

    //Retorna o valor do Erro1
    public static double getErro1(int row, int col)
    {
        return Math.Round(erro1[row, col], nDecimais);
    }

    //Atribui o valor de Erro1.
    public static void setErro1(int row, int col, double value)
    {
        erro1[row, col] = value;
    }

    //Retorna o valor do Netout
    public static double getNetout(int row, int col)
    {
        return Math.Round(netout[row, col], nDecimais);
    }

    //Atribui o valor de Netout.
    public static void setNetout(int row, int col, double value)
    {
        netout[row, col] = value;
    }

    //Retorna o valor do erro2
    public static double getErro2(int row, int col)
    {
        return Math.Round(erro2[row, col], nDecimais);
    }

    //Atribui o valor de erro2.
    public static void setErro2(int row, int col, double value)
    {
        erro2[row, col] = value;
    }

    //Inicializa o valor da matriz Pesos2.
    public static void initPesos2(int row, int col)
    {
        pesos2 = new double[row, col];
    }

    //Inicializa o valor da matriz Prdlwt1.
    public static void initAntigodeltapesos1(int row, int col)
    {
        antigodeltapesos1 = new double[row, col];
    }

    //Inicializa o valor da matriz Antigodeltapesos2.
    public static void initAntigodeltapesos2(int row, int col)
    {
        antigodeltapesos2 = new double[row, col];
    }

    //Inicializa o valor da matriz Deltapesos1.
    public static void initDeltapesos1(int row, int col)
    {
        deltapesos1 = new double[row, col];
    }

    //Inicializa o valor da matriz Deltapesos2.
    public static void initDeltapesos2(int row, int col)
    {
        deltapesos2 = new double[row, col];
    }

    //Inicializa o valor da matriz Net2.
    public static void initNet2(int row, int col)
    {
        net2 = new double[row, col];
    }

    //Inicializa o valor da matriz Erro1.
    public static void initErro1(int row, int col)
    {
        erro1 = new double[row, col];
    }

    //Inicializa o valor da matriz Net2.
    public static void initNetout(int row, int col)
    {
        netout = new double[row, col];
    }

    //Inicializa o valor da matriz erro2.
    public static void initErro2(int row, int col)
    {
        erro2 = new double[row, col];
    }

    //Retorna o valor da matriz de entrada.
    public static double getEntradas(int row, int col)
    {
        return entradas[row, col];
    }

    //Retorna o valor da matriz de saidas.
    public static double getSaidas(int row, int col)
    {
        return saidas[row, col];
    }

    //Inicialização dos pesos.
    public static void randomize()
    {

        //Cria uma instância de Random
        Random random = new Random(Convert.ToInt32(getSemente()));

        for (int j = 0; j < getnumEscondidas(); j++)
        {
            setVies1(j, -1 + random.Next(8192) / 8192);
            setAntigodeltabs1(j, 0.0d);
            setDeltabs1(j, 0.0d);

            for (int i = 0; i < getnumEntradas(); i++)
            {
                setPesos1(j, i, random.Next(8192) / 8192 - 0.5d);
                setAntigodeltapesos1(j, i, 0.0d);
                setDeltapesos1(j, i, 0.0d);
            }
        }

        for (int j = 0; j < getnumSaidas(); j++)
        {
            setVies2(j, -0.1d + random.Next(8192) / 8192);
            setAntigodeltabs2(j, 0.0d);
            for (int i = 0; i < getnumEscondidas(); i++)
            {
                setPesos2(j, i, 0.1d * random.Next(8192) / 8192 - 0.05);
                setAntigodeltapesos2(j, i, 0.0d);
                setDeltapesos2(j, i, 0.0d);
            }
        }
    }

    //Forward e Backward (backpropagation)
    public static ArrayList Forward()
    {
        //Ciclos
        for (int kl = 0; kl < getCiclos(); kl++)
        {
            setCicloAtual(getCicloAtual() + 1);

            //Exemplos
            for (int iteracao = 0; iteracao < getnumTreinamentos(); iteracao++)
            {

                double ea, eb;

                //Forward
                for (int j = 0; j < getnumEscondidas(); j++)
                {
                    //Função Net
                    setNet1(j, getVies1(j));
                    for (int i = 0; i < getnumEntradas(); i++)
                    {
                        setNet1(j, Math.Round(getNet1(j) + (getPesos1(j, i) * getEntradas(iteracao, i)), 2));
                    }

                    ea = Math.Round((double)(Math.Exp((double)((-1.0d) * (getNet1(j))))), nDecimais);

                    //Função de ativação: Sigmóide Logística
                    setFnet1(j, Math.Round((double)(1.0) / (1.0 + (ea)), nDecimais) );
                }

                for (int j = 0; j < getnumSaidas(); j++)
                {
                    //Função Net
                    setNet2(iteracao, j, getVies2(j));
                    for (int i = 0; i < getnumEscondidas(); i++)
                    {
                        setNet2(iteracao, j, Math.Round(getNet2(iteracao, j) + (getPesos2(j, i) * getFnet1(i)), nDecimais));
                    }

                    eb = Math.Round((double)(Math.Exp((double)((-1.0d) * (getNet2(iteracao, j))))), nDecimais);

                    //Função de ativação: Sigmóide Logística
                    setNetout(iteracao, j, Math.Round((double)(1.0 / (1.0 + eb)), nDecimais));
                }

                //Backward
                for (int j = 0; j < getnumSaidas(); j++)
                {
                    //Erro
                    setErro2(iteracao, j, Math.Round((getSaidas(iteracao, j) - getNetout(iteracao, j)), nDecimais));

                    //impressão dos dados
                    System_out_println.Add("********************************************************************");
                    System_out_println.Add("Ciclo:" + " " + getCicloAtual() + "; " + "Exemplo:" + " " + (iteracao + 1) + "; ");
                    System_out_println.Add("Saída desejada:" + " " + Math.Round(getSaidas(iteracao, j), nDecimais) + "; ");
                    System_out_println.Add("Saída calculada:" + " " + Math.Round(getNetout(iteracao, j), nDecimais) + "; ");
                    System_out_println.Add("Erro:" + " " + Math.Round(getErro2(iteracao, j), nDecimais) + "; ");

                    //Regra delta
                    setDeltabs2(j, Math.Round((getAlfa() * getErro2(iteracao, j)) * getNetout(iteracao, j) * (1.0 - getNetout(iteracao, j)) + (getBeta() * getAntigodeltabs2(j)), nDecimais));

                    for (int i = 0; i < getnumEscondidas(); i++)
                    {
                        //Regra delta
                        setDeltapesos2(j, i, Math.Round((getAlfa() * getErro2(iteracao, j) * getNetout(iteracao, j) * (1.0 - getNetout(iteracao, j)) * getFnet1(i)) + (getBeta() * getAntigodeltapesos2(j, i)), nDecimais));
                    }
                }

                for (int j = 0; j < getnumEscondidas(); j++)
                {
                    setSensibilidade1(j, 0.0d);
                    for (int i = 0; i < getnumSaidas(); i++)
                    {
                        //Sensibilidade
                        setSensibilidade1(j, Math.Round(getSensibilidade1(j) + (getErro2(iteracao, i) * getPesos2(i, j)), nDecimais));
                    }

                    //Erro
                    setErro1(iteracao, j, Math.Round((getFnet1(j)) * (1.0d - getFnet1(j)) * getSensibilidade1(j), nDecimais));

                    //Regra delta
                    setDeltabs1(j, Math.Round((getAlfa() * getErro1(iteracao, j)) + (getBeta() * getAntigodeltabs1(j)), nDecimais));

                    for (int ii = 0; ii < getnumEntradas(); ii++)
                    {
                        //Regra delta
                        setDeltapesos1(j, ii, Math.Round((getAlfa() * getErro1(iteracao, j)) * (getEntradas(iteracao, ii)) + (getBeta() * getAntigodeltapesos1(j, ii)), nDecimais));
                    }
                }

                for (int j = 0; j < getnumEscondidas(); j++)
                {
                    setVies1(j, Math.Round(getDeltabs1(j) + getVies1(j), nDecimais));
                    setAntigodeltabs1(j, getDeltabs1(j));

                    //impressão dos dados
                    System_out_println.Add("Viés:" + " " + (j + 1) + "; " + Math.Round(getVies1(j), nDecimais) + "; ");

                    for (int ii = 0; ii < getnumEntradas(); ii++)
                    {

                        setPesos1(j, ii, Math.Round(getPesos1(j, ii) + (getDeltapesos1(j, ii)), nDecimais));

                        //impressão dos dados
                        System_out_println.Add("Peso:" + " " + (j + 1) + " " + (ii + 1) + "; " + Math.Round(getPesos1(j, ii), nDecimais) + "; ");

                        setAntigodeltapesos1(j, ii, getDeltapesos1(j, ii));
                    }
                }

                for (int j = 0; j < getnumSaidas(); j++)
                {
                    setVies2(j, Math.Round(getDeltabs2(j) + getVies2(j), nDecimais));
                    setAntigodeltabs2(j, getDeltabs2(j));

                    //impressão dos dados
                    System_out_println.Add("Viés:" + " " + (j + 1) + "; " + Math.Round(getVies2(j), nDecimais) + "; ");

                    for (int i = 0; i < getnumEscondidas(); i++)
                    {
                        setPesos2(j, i, Math.Round(getPesos2(j, i) + (getDeltapesos2(j, i)), nDecimais));
                        setAntigodeltapesos2(j, i, getDeltapesos2(j, i));

                        //impressão dos dados
                        System_out_println.Add("Peso:" + " " + (j + 1) + " " + (i + 1) + "; " + Math.Round(getPesos2(j, i), nDecimais) + "; ");
                    }
                }
            }
        }
        return (System_out_println);
    }

    //Método para carga da página.
    protected void Page_Load(object sender, EventArgs e)
    {
        try
        {
            if (!IsPostBack)
            {
            }
        }
        catch
        {
        }
    }

    //Função de ativação
    protected void DropDownListAtivacao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListAtivacao.SelectedValue == "Linear")
        {
            DropDownListAtivacao.ToolTip = "f(x)=x | f'(x)=x";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
        else if (DropDownListAtivacao.SelectedValue == "Degrau")
        {
            DropDownListAtivacao.ToolTip = "f(x)=1; se x>=0->0:1 | f'(x)=?; se x=0->0";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
        else if (DropDownListAtivacao.SelectedValue == "Sigmóide")
        {
            DropDownListAtivacao.ToolTip = "f(x)=1/(1+e^(-x)) | f'(x)=f(x)(1-f(x))";
            LabelMensagem.Text = "";
        }
        else if (DropDownListAtivacao.SelectedValue == "Hiperbólica")
        {
            DropDownListAtivacao.ToolTip = "f(x)=(e^x-e^-x)/(e^x+e^-x) | f'(x)=1-f(x)^2";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
        else if (DropDownListAtivacao.SelectedValue == "ReLu")
        {
            DropDownListAtivacao.ToolTip = "f(x)=x se x>=0->0 | f'(x)=1; se x>=0->0";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
        else if (DropDownListAtivacao.SelectedValue == "Leaky ReLu")
        {
            DropDownListAtivacao.ToolTip = "f(x)=x; se x>=0->0,01x | f'(x)=1; se x>=0->0,01";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
        else if (DropDownListAtivacao.SelectedValue == "Soft Max")
        {
            DropDownListAtivacao.ToolTip = "f(x)=(e^xi)/(ΣKj=1e^xj)";
            LabelMensagem.Text = "[Função de ativação não implementada]";
        }
    }

    //Tipos de normalização
    protected void DropDownListNormalizacao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListNormalizacao.SelectedValue == "Simples")
        {
            DropDownListNormalizacao.ToolTip = "Simples: n/max(n) | n*max(n)";
            LabelMensagem.Text = "[Função custo não implementada]";
        }
        else if (DropDownListNormalizacao.SelectedValue == "Linear")
        {
            DropDownListNormalizacao.ToolTip = "Linear: (b-a)*(n-min(n))/(max(n)-min(n))+a | (n-a)*(max(n)-min(n))/(b-a)+min(n)";
            LabelMensagem.Text = "[Função custo não implementada]";
        }
    }

    //Função custo
    protected void DropDownListFuncaoCusto_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListFuncaoCusto.SelectedValue == "EC")
        {
            DropDownListFuncaoCusto.ToolTip = "Entropia Cruzada: função custo para classificação";
            LabelMensagem.Text = "[Função custo não implementada]";
            CheckBoxCusto.Text = "EC";
        }
        else if (DropDownListFuncaoCusto.SelectedValue == "L1")
        {
            DropDownListFuncaoCusto.ToolTip = "Erro Médio Absoluto (EMA): função custo para predição";
            LabelMensagem.Text = "[Função custo não implementada]";
            CheckBoxCusto.Text = "EMA";
        }
        else if (DropDownListFuncaoCusto.SelectedValue == "L2")
        {
            DropDownListFuncaoCusto.ToolTip = "Erro Médio Quadrático (EMQ): função custo para predição";
            LabelMensagem.Text = "";
            CheckBoxCusto.Text = "EMQ";
        }
    }

    //Avaliação de desempenho
    protected void DropDownListDesempenho_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListDesempenho.SelectedValue == "MSE")
        {
            DropDownListDesempenho.ToolTip = "MSE";
            LabelMensagem.Text = "[Avaliação de desempenho não implementada]";
        }
        else if (DropDownListDesempenho.SelectedValue == "MAE")
        {
            DropDownListDesempenho.ToolTip = "MAE";
            LabelMensagem.Text = "[Avaliação de desempenho não implementada]";
        }
        else if (DropDownListDesempenho.SelectedValue == "MAPE")
        {
            DropDownListDesempenho.ToolTip = "MAPE";
            LabelMensagem.Text = "[Avaliação de desempenho não implementada]";
        }
        else if (DropDownListDesempenho.SelectedValue == "")
        {
            DropDownListDesempenho.ToolTip = "";
            LabelMensagem.Text = "";
        }
    }

    //Arquitetura da rede
    protected void DropDownListArquitetura_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListArquitetura.SelectedValue == "CNN")
        {
            DropDownListArquitetura.ToolTip = "Convolutional Neural Network";
            LabelMensagem.Text = "[Arquitetura da rede não implementada]";
        }
        else if (DropDownListArquitetura.SelectedValue == "RNN")
        {
            DropDownListArquitetura.ToolTip = "Recurrent Neural Network";
            LabelMensagem.Text = "[Arquitetura da rede não implementada]";
        }
        else if (DropDownListArquitetura.SelectedValue == "MLP")
        {
            DropDownListArquitetura.ToolTip = "Multilayer Perceptron";
            LabelMensagem.Text = "";
        }
    }

    //Algoritmo de otimização
    protected void DropDownListOtimizacao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListOtimizacao.SelectedValue == "Momentum")
        {
            DropDownListOtimizacao.ToolTip = "Momentum";
        }
        else if (DropDownListOtimizacao.SelectedValue == "Adagrad")
        {
            DropDownListOtimizacao.ToolTip = "Adagrad";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "RMSprop")
        {
            DropDownListOtimizacao.ToolTip = "RMSProp";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "Adadelta")
        {
            DropDownListOtimizacao.ToolTip = "Adadelta";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "Nesterov")
        {
            DropDownListOtimizacao.ToolTip = "Nesterov";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "Adam")
        {
            DropDownListOtimizacao.ToolTip = "Adam";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "Adamax")
        {
            DropDownListOtimizacao.ToolTip = "Adamax";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
        else if (DropDownListOtimizacao.SelectedValue == "AMSGrad")
        {
            DropDownListOtimizacao.ToolTip = "AMSGrad";
            LabelMensagem.Text = "[Algoritmo de otimização não implementado]";
        }
    }

    //Forma de ajuste
    protected void DropDownListAjuste_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListAjuste.SelectedValue == "Online")
        {
            DropDownListAjuste.ToolTip = "Online";
        }
        else if (DropDownListAjuste.SelectedValue == "Batch")
        {
            DropDownListAjuste.ToolTip = "Batch";
            LabelMensagem.Text = "[Forma de ajuste não implementada]";
        }
        else if (DropDownListAjuste.SelectedValue == "Minibatch")
        {
            DropDownListAjuste.ToolTip = "Minibatch";
            LabelMensagem.Text = "[Forma de ajuste não implementada]";
        }
    }

    //Dimensão da rede
    protected void DropDownListDimensao_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownListDimensao.SelectedValue == "SNN")
        {
            DropDownListDimensao.ToolTip = "Simple Neural Network";
        }
        else if (DropDownListDimensao.SelectedValue == "DNN")
        {
            DropDownListDimensao.ToolTip = "Deeplearn Neural Network";
            LabelMensagem.Text = "[Dimensão não implementada]";
        }
    }

    //Limpar objetos de saída.
    protected void ButtonLimpar_Click(object sender, EventArgs e)
    {
        try
        {
            ButtonNormalizar.Enabled = true;
            ButtonDesnormalizar.Enabled = true;

            CheckBoxEMPA.Text = "EMPA:";
            LabelTempo.Text = "";

            TextBoxEntrada.Text = "1";
            TextBoxSaida.Text = "1";

            LabelMensagem.Text = "";
            LabelEntradasLin.Text = "Entradas (x)";
            LabelSaidasLin.Text = "Saídas (y)";
            LabelEntradasLinhas.Text = "0";

            System_out_println.Clear();

            TextBoxSaidaEMQs.Text = "";
            TextBoxSaidaErros.Text = "";
            TextBoxSaidaCiclos.Text = "";
            TextBoxSaidaExemplos.Text = "";
            TextBoxSaidaTreinamentos.Text = "";

        }
        catch
        {
        }
    }

    //Ler conteúdo de arquivo texto e preencher listbox.
    protected void ButtonLer_Click(object sender, EventArgs e)
    {
        try
        {
            bool PrimeiraLinha = true;
            int nLin = 0;
            int nCol = 0;
            int nTam = TextBoxLerEntradas.Text.Length;
            for (int i = 0; i <= nTam - 1; i++)
            {
                if (PrimeiraLinha)
                {
                    if (TextBoxLerEntradas.Text[i].ToString() == ";")
                    {
                        nCol = nCol + 1;
                    }
                }
                if (TextBoxLerEntradas.Text[i].ToString() == "\n")
                {
                    nLin = nLin + 1;
                    PrimeiraLinha = false;
                }
            }
            
            LabelEntradasLinhas.Text = nLin.ToString();
            LabelEntradasColunas.Text = (nCol + 1).ToString();

            TextBoxExemplos.Text = LabelEntradasLinhas.Text;
            TextBoxEntrada.Text = LabelEntradasColunas.Text;

            PrimeiraLinha = true;
            nLin = 0;
            nCol = 0;
            nTam = TextBoxLerSaidas.Text.Length;
            for (int i = 0; i <= nTam - 1; i++)
            {
                if (PrimeiraLinha)
                {
                    if (TextBoxLerSaidas.Text[i].ToString() == ";")
                    {
                        nCol = nCol + 1;
                    }
                }
                if (TextBoxLerSaidas.Text[i].ToString() == "\n")
                {
                    nLin = nLin + 1;
                    PrimeiraLinha = false;
                }
            }

            LabelSaidasLinhas.Text = nLin.ToString();
            LabelSaidasColunas.Text = (nCol + 1).ToString();

            TextBoxSaida.Text = LabelSaidasColunas.Text;

            MinMax();
        
        }
        catch
        {
        }
    }

    //Treina rede.
    protected void ButtonTreinar_Click(object sender, EventArgs e)
    {
        try
        {
            ButtonLer_Click(null, null);

            LabelTempo.Text = "Início " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");

            //Valor Limite
            if ((TextBoxLimite.Visible) && (Convert.ToInt32(TextBoxLimite.Text) < Convert.ToInt32(TextBoxExemplos.Text)))
            {
                TextBoxExemplos.Text = TextBoxLimite.Text;
            }
            
            LabelMensagem.Text = "";
            System_out_println.Clear();

            TextBoxSaidaEMQs.Text = "";
            TextBoxSaidaErros.Text = "";
            TextBoxSaidaCiclos.Text = "";
            TextBoxSaidaExemplos.Text = "";
            TextBoxSaidaTreinamentos.Text = "";

            nDecimais = Convert.ToInt32(TextBoxDecimais.Text);

            setSemente(Convert.ToInt32(TextBoxSemente.Text));
            setCiclos(Convert.ToInt32(TextBoxCiclos.Text));
            setCicloAtual(0);
            setnumEntradas(Convert.ToInt32(TextBoxEntrada.Text));
            setnumEscondidas(Convert.ToInt32(TextBoxEscondida.Text));
            setnumSaidas(Convert.ToInt32(TextBoxSaida.Text));
            setnumTreinamentos(Convert.ToInt32(TextBoxExemplos.Text));
            setAlfa(Convert.ToDouble(TextBoxTaxaAprendizagem.Text));
            setBeta(Convert.ToDouble(TextBoxMomento.Text));

            //Inicializar o tamanho das matrizes.
            initPesos1(getnumEscondidas(), getnumEntradas());
            initAntigodeltapesos1(getnumEscondidas(), getnumEntradas());
            initDeltapesos1(getnumEscondidas(), getnumEntradas());

            initPesos2(getnumSaidas(), getnumEscondidas());
            initAntigodeltapesos2(getnumSaidas(), getnumEscondidas());
            initDeltapesos2(getnumSaidas(), getnumEscondidas());

            initNet2(getnumTreinamentos(), getnumSaidas());
            initNetout(getnumTreinamentos(), getnumSaidas());
            initErro2(getnumTreinamentos(), getnumSaidas());

            initErro1(getnumTreinamentos(), getnumEscondidas());

            //Inicia os pesos aleatórios.
            randomize();

            //Inicializa os valores da matriz de entradas (1x7).
            double[,] entradasIniciais = { { 1.50 }, { 2.00 }, { 2.50 }, { 3.00 }, { 3.50 }, { 4.00 }, { 4.5 } };

            entradas = entradasIniciais;

            //Inicializa os valores da matriz de saidas (1x7).
            double[,] saidasIniciais = { { 0.02 }, { 0.08 }, { 0.18 }, { 0.50 }, { 0.65 }, { 0.88 }, { 0.96 } };

            saidas = saidasIniciais;

            //Número de linhas lidas
            int nLinhas = Convert.ToInt32(LabelEntradasLinhas.Text);

            //Índice da matriz
            int nIndice = Convert.ToInt32(TextBoxLimite.Text.ToString());

            //Reinicializa os valores da matriz de entrada e saída com os valores lidos
            if (nLinhas > 0)
            {
                System.Globalization.CultureInfo formatoUS = new System.Globalization.CultureInfo("en-US");

                int nEntrada = Convert.ToInt32(TextBoxEntrada.Text);
                ArrayList alEntradas = StringToArray(TextBoxLerEntradas.Text, "\n", 1);

                double[,] novasEntradasIniciais = new double[nLinhas, nEntrada];

                //Valor Limite
                if ((TextBoxLimite.Visible) && (Convert.ToInt32(TextBoxLimite.Text) < Convert.ToInt32(TextBoxExemplos.Text)))
                {
                    nLinhas = Convert.ToInt32(TextBoxLimite.Text);
                    novasEntradasIniciais = new double[nLinhas, nEntrada];
                }

                for (int i = 0; i <= nLinhas - 1; i++)
                {

                    ArrayList alEntrada = StringToArray(alEntradas[i].ToString(), ";", 1);

                    for (int j = 0; j <= alEntrada.Count - 1; j++)
                    {
                        try
                        {
                            if (DropDownListSeparador.SelectedValue == "Vírgula")
                            {
                                double nElemento = Math.Round(Convert.ToDouble(alEntrada[j].ToString().Replace("\n", "").Replace(".", ",")), nDecimais);
                                novasEntradasIniciais[i, j] = nElemento;
                            }
                            else
                            {
                                double nElemento = Math.Round(Convert.ToDouble(alEntrada[j].ToString().Replace("\n", "").Replace(",", ".")), nDecimais);
                                novasEntradasIniciais[i, j] = nElemento;
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }
                    
                }

                entradas = novasEntradasIniciais;

                int nSaida = Convert.ToInt32(TextBoxSaida.Text);
                ArrayList alSaidas = StringToArray(TextBoxLerSaidas.Text, "\n", 1);

                double[,] novasSaidasIniciais = new double[nLinhas, nSaida];

                //Valor Limite
                if ((TextBoxLimite.Visible) && (Convert.ToInt32(TextBoxLimite.Text) < Convert.ToInt32(TextBoxExemplos.Text)))
                {
                    nLinhas = Convert.ToInt32(TextBoxLimite.Text);
                    novasSaidasIniciais = new double[nLinhas, nEntrada];
                }

                for (int i = 0; i <= nLinhas - 1; i++)
                {

                    ArrayList alSaida = StringToArray(alSaidas[i].ToString(), ";", 1);

                    for (int j = 0; j <= alSaida.Count - 1; j++)
                    {
                        try
                        {
                            if (DropDownListSeparador.SelectedValue == "Vírgula")
                            {
                                double nElemento = Math.Round(Convert.ToDouble(alSaida[j].ToString().Replace("\n", "").Replace(".", ",")), nDecimais);
                                novasSaidasIniciais[i, j] = nElemento;
                            }
                            else
                            {
                                double nElemento = Math.Round(Convert.ToDouble(alSaida[j].ToString().Replace("\n", "").Replace(",", ".")), nDecimais);
                                novasSaidasIniciais[i, j] = nElemento;
                            }
                        }
                        catch
                        {
                            break;
                        }
                    }

                }

                saidas = novasSaidasIniciais;

            }

            //Executa os métodos forward e backward.
            //////////////////////////////
            ArrayList retorno = Forward();
            //////////////////////////////

            //Exibe os dados em memória na tela.
            if (CheckBoxTreinamento.Checked)
            {
                for (int i = 0; i <= retorno.Count - 1; i++)
                {
                    TextBoxSaidaTreinamentos.Text = TextBoxSaidaTreinamentos.Text + retorno[i].ToString() + "\n";
                }
                TextBoxSaidaTreinamentos.Text = TextBoxSaidaTreinamentos.Text + "******************************* fim ********************************";
            }

            //Calcula o erro métrico quadrático
            ArrayList alErro = new ArrayList();
            double nErro = 0.0;
            double nEMPA = 0.0;
            int nEMPAqtde = 0;
            int nQtde = 0;
            int nCiclo = 0;
            int nExemplo = 0;
            bool bNovoCiclo = false;
            bool bNovoExemplo = false;
            String sCicloExemplo = "";
            String sExemplo = "";
            for (int i = 0; i <= retorno.Count - 1; i++)
            {
                try
                {
                    //Breakpoint
                    if (sExemplo == "400")
                    {
                        bool bParar = true;
                    }

                    //Obtém ciclo.
                    String sCiclo = retorno[i].ToString();
                    if (sCiclo.IndexOf("Ciclo") != -1)
                    {
                        sCicloExemplo = sCiclo;
                        sCiclo = sCiclo.Substring(0, sCiclo.IndexOf(";")).Replace("Ciclo: ", "").Replace("; ", "");
                        nCiclo = Convert.ToInt32(sCiclo);
                        if (TextBoxSaidaCiclos.Text.IndexOf(sCiclo) == -1)
                        {
                            if (CheckBoxCiclos.Checked)
                            {
                                TextBoxSaidaCiclos.Text = TextBoxSaidaCiclos.Text + sCiclo + "\n";
                            }
                            bNovoCiclo = true;
                        }
                    }

                    //Obtém exemplo.
                    String sExemploCorrente = retorno[i].ToString();
                    if (sExemploCorrente.IndexOf("Exemplo") != -1)
                    {
                        sExemplo = sExemploCorrente;
                        sExemplo = sExemplo.Substring(sExemplo.IndexOf("Exemplo: ")).Replace("Exemplo: ", "").Replace("; ", "").Trim();
                        nExemplo = Convert.ToInt32(sExemplo);
                        if (TextBoxSaidaExemplos.Text.IndexOf(sExemplo) == -1)
                        {
                            if (CheckBoxExemplos.Checked)
                            {
                                TextBoxSaidaExemplos.Text = TextBoxSaidaExemplos.Text + sExemplo + "\n";
                            }
                            bNovoExemplo = true;
                        }
                    }

                    //Acumula o erro.
                    String sErro = retorno[i].ToString();
                    if (sErro.IndexOf("Erro") != -1)
                    {
                        sErro = sErro.Substring(0, sErro.IndexOf(";")).Replace("Erro: ", "").Replace("; ", "");
                        nErro = nErro + Convert.ToDouble(sErro);
                        nQtde = nQtde + 1;
                        if (CheckBoxErro.Checked)
                        {
                            TextBoxSaidaErros.Text = TextBoxSaidaErros.Text + sCicloExemplo + sErro + "\n";
                        }
                    }

                    //Verifica se mudou o exemplo e imprime a função custo.
                    if ((bNovoExemplo) && (nExemplo > 1))
                    {
                        //função custo EMQ
                        if (nQtde != 0)
                        {
                            nErro = Math.Round(Math.Pow(nErro / nQtde, 2), nDecimais);
                        }
                        nEMPA = nEMPA + nErro;
                        nEMPAqtde = nEMPAqtde + 1;
                        if (CheckBoxCusto.Checked)
                        {
                            TextBoxSaidaEMQs.Text = TextBoxSaidaEMQs.Text + nErro.ToString() + "\n";
                        }
                        nErro = 0.0;
                        nQtde = 0;
                        bNovoCiclo = false;
                        bNovoExemplo = false;
                    }

                }
                catch
                {
                }
            }

            //imprime o último EMQ.
            if (CheckBoxCusto.Checked)
            {
                TextBoxSaidaEMQs.Text = TextBoxSaidaEMQs.Text + Math.Round(Math.Pow(nErro / nQtde, 2), nDecimais).ToString();
            }

            //imprime o EMPA.
            if (CheckBoxEMPA.Checked)
            {
                CheckBoxEMPA.Text = "EMPA: " + Math.Round(((nEMPA / nEMPAqtde) * 100), nDecimais).ToString();
            }

            //imprime o tempo do processamento.
            LabelTempo.Text = LabelTempo.Text + " Término " + DateTime.Now.Hour.ToString("00") + ":" + DateTime.Now.Minute.ToString("00") + ":" + DateTime.Now.Second.ToString("00");
        }
        catch (Exception ex)
        {
            LabelMensagem.Text = ex.Message;
        }
    }

    //Normaliza os dados dos campos de entrada e saída
    protected void ButtonNormalizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBoxEntradasMin.Text.Trim() == "")
            {
                MinMax();
            }

            ButtonNormalizar.Enabled = false;
            ButtonDesnormalizar.Enabled = true;
            nDecimais = Convert.ToInt32(TextBoxDecimais.Text);

            String sAux = "";

            //Entradas
            if (TextBoxLerEntradas.Text.Trim() != "")
            {
                StringBuilder sbLinhas = new StringBuilder(); 
                ArrayList alEntradasMin = StringToArray(TextBoxEntradasMin.Text, ";", 1);
                ArrayList alEntradasMax = StringToArray(TextBoxEntradasMax.Text, ";", 1);
                ArrayList alLinhasEntradas = StringToArray(TextBoxLerEntradas.Text, "\n", 1);
                for (int nLin = 0; nLin <= alLinhasEntradas.Count - 1; nLin++)
                {
                    sAux = "";
                    if (alLinhasEntradas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunasEntradas = StringToArray(alLinhasEntradas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunasEntradas.Count - 1; nCol++)
                        {
                            if (alColunasEntradas[nCol].ToString().Trim() != "")
                            {
                                double nMin = 0;
                                double nMax = 0;
                                double nValor = 0;
                                double nValorNormalizado = 0;
                                if (DropDownListSeparador.SelectedValue == "Ponto")
                                {
                                    nMin = Convert.ToDouble(alEntradasMin[nCol].ToString().Trim().Replace(",", "."));
                                    nMax = Convert.ToDouble(alEntradasMax[nCol].ToString().Trim().Replace(",", "."));
                                    nValor = Convert.ToDouble(alColunasEntradas[nCol].ToString().Trim().Replace(",", "."));
                                    nValorNormalizado = Math.Round((nValor / nMax), nDecimais);
                                }
                                else
                                {
                                    nMin = Convert.ToDouble(alEntradasMin[nCol].ToString().Trim().Replace(".", ","));
                                    nMax = Convert.ToDouble(alEntradasMax[nCol].ToString().Trim().Replace(".", ","));
                                    nValor = Convert.ToDouble(alColunasEntradas[nCol].ToString().Trim().Replace(".", ","));
                                    nValorNormalizado = Math.Round((nValor / nMax), nDecimais);
                                }
                                sAux = sAux + nValorNormalizado.ToString() + ";";
                            }
                        }
                        sAux = sAux.Substring(0, sAux.Length - 1) + "\n";
                    }
                    sbLinhas.Append(sAux);
                }
                TextBoxLerEntradas.Text = sbLinhas.ToString();
            }

            //Saídas
            if (TextBoxLerSaidas.Text.Trim() != "")
            {
                StringBuilder sbLinhas = new StringBuilder();
                ArrayList alSaidasMin = StringToArray(TextBoxSaidaMin.Text, ";", 1);
                ArrayList alSaidasMax = StringToArray(TextBoxSaidaMax.Text, ";", 1);
                ArrayList alLinhasSaidas = StringToArray(TextBoxLerSaidas.Text, "\n", 1);
                for (int nLin = 0; nLin <= alLinhasSaidas.Count - 1; nLin++)
                {
                    sAux = "";
                    if (alLinhasSaidas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunasSaidas = StringToArray(alLinhasSaidas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunasSaidas.Count - 1; nCol++)
                        {
                            if (alColunasSaidas[nCol].ToString().Trim() != "")
                            {
                                double nMin = 0;
                                double nMax = 0;
                                double nValor = 0;
                                double nValorNormalizado = 0;
                                if (DropDownListSeparador.SelectedValue == "Ponto")
                                {
                                    nMin = Convert.ToDouble(alSaidasMin[nCol].ToString().Trim().Replace(",", "."));
                                    nMax = Convert.ToDouble(alSaidasMax[nCol].ToString().Trim().Replace(",", "."));
                                    nValor = Convert.ToDouble(alColunasSaidas[nCol].ToString().Trim().Replace(",", "."));
                                    nValorNormalizado = Math.Round((nValor / nMax), nDecimais);
                                }
                                else
                                {
                                    nMin = Convert.ToDouble(alSaidasMin[nCol].ToString().Trim().Replace(".", ","));
                                    nMax = Convert.ToDouble(alSaidasMax[nCol].ToString().Trim().Replace(".", ","));
                                    nValor = Convert.ToDouble(alColunasSaidas[nCol].ToString().Trim().Replace(".", ","));
                                    nValorNormalizado = Math.Round((nValor / nMax), nDecimais);
                                }
                                sAux = sAux + nValorNormalizado.ToString() + ";";
                            }
                        }
                        sAux = sAux.Substring(0, sAux.Length - 1) + "\n";
                    }
                    sbLinhas.Append(sAux);
                }
                TextBoxLerSaidas.Text = sbLinhas.ToString();
            }

        }
        catch
        {
        }
    }

    //Desnormaliza os dados dos campos de entrada e saída
    protected void ButtonDesnormalizar_Click(object sender, EventArgs e)
    {
        try
        {
            if (TextBoxEntradasMin.Text.Trim() == "")
            {
                MinMax();
            }

            ButtonNormalizar.Enabled = true;
            ButtonDesnormalizar.Enabled = false;
            nDecimais = Convert.ToInt32(TextBoxDecimais.Text);

            String sAux = "";

            //Entradas
            if (TextBoxLerEntradas.Text.Trim() != "")
            {
                StringBuilder sbLinhas = new StringBuilder();
                ArrayList alEntradasMin = StringToArray(TextBoxEntradasMin.Text, ";", 1);
                ArrayList alEntradasMax = StringToArray(TextBoxEntradasMax.Text, ";", 1);
                ArrayList alLinhasEntradas = StringToArray(TextBoxLerEntradas.Text, "\n", 1);
                for (int nLin = 0; nLin <= alLinhasEntradas.Count - 1; nLin++)
                {
                    sAux = "";
                    if (alLinhasEntradas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunasEntradas = StringToArray(alLinhasEntradas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunasEntradas.Count - 1; nCol++)
                        {
                            if (alColunasEntradas[nCol].ToString().Trim() != "")
                            {
                                double nMin = 0;
                                double nMax = 0;
                                double nValor = 0;
                                double nValorDesnormalizado = 0;
                                if (DropDownListSeparador.SelectedValue == "Ponto")
                                {
                                    nMin = Convert.ToDouble(alEntradasMin[nCol].ToString().Trim().Replace(",", "."));
                                    nMax = Convert.ToDouble(alEntradasMax[nCol].ToString().Trim().Replace(",", "."));
                                    nValor = Convert.ToDouble(alColunasEntradas[nCol].ToString().Trim().Replace(",", "."));
                                    nValorDesnormalizado = Math.Round((nValor * nMax), 0);
                                }
                                else
                                {
                                    nMin = Convert.ToDouble(alEntradasMin[nCol].ToString().Trim().Replace(".", ","));
                                    nMax = Convert.ToDouble(alEntradasMax[nCol].ToString().Trim().Replace(".", ","));
                                    nValor = Convert.ToDouble(alColunasEntradas[nCol].ToString().Trim().Replace(".", ","));
                                    nValorDesnormalizado = Math.Round((nValor * nMax), 0);
                                }
                                sAux = sAux + nValorDesnormalizado.ToString() + ";";
                            }
                        }
                        sAux = sAux.Substring(0, sAux.Length - 1) + "\n";
                    }
                    sbLinhas.Append(sAux);
                }
                TextBoxLerEntradas.Text = sbLinhas.ToString();
            }

            //Saídas
            if (TextBoxLerSaidas.Text.Trim() != "")
            {
                StringBuilder sbLinhas = new StringBuilder();
                ArrayList alSaidasMin = StringToArray(TextBoxSaidaMin.Text, ";", 1);
                ArrayList alSaidasMax = StringToArray(TextBoxSaidaMax.Text, ";", 1);
                ArrayList alLinhasSaidas = StringToArray(TextBoxLerSaidas.Text, "\n", 1);
                for (int nLin = 0; nLin <= alLinhasSaidas.Count - 1; nLin++)
                {
                    sAux = "";
                    if (alLinhasSaidas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunasSaidas = StringToArray(alLinhasSaidas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunasSaidas.Count - 1; nCol++)
                        {
                            if (alColunasSaidas[nCol].ToString().Trim() != "")
                            {
                                double nMin = 0;
                                double nMax = 0;
                                double nValor = 0;
                                double nValorDesnormalizado = (nValor * nMax);
                                if (DropDownListSeparador.SelectedValue == "Ponto")
                                {
                                    nMin = Convert.ToDouble(alSaidasMin[nCol].ToString().Trim().Replace(",", "."));
                                    nMax = Convert.ToDouble(alSaidasMax[nCol].ToString().Trim().Replace(",", "."));
                                    nValor = Convert.ToDouble(alColunasSaidas[nCol].ToString().Trim().Replace(",", "."));
                                    nValorDesnormalizado = Math.Round((nValor * nMax), 0);
                                }
                                else
                                {
                                    nMin = Convert.ToDouble(alSaidasMin[nCol].ToString().Trim().Replace(".", ","));
                                    nMax = Convert.ToDouble(alSaidasMax[nCol].ToString().Trim().Replace(".", ","));
                                    nValor = Convert.ToDouble(alColunasSaidas[nCol].ToString().Trim().Replace(".", ","));
                                    nValorDesnormalizado = Math.Round((nValor * nMax), 0);
                                }
                                sAux = sAux + nValorDesnormalizado.ToString() + ";";
                            }
                        }
                        sAux = sAux.Substring(0, sAux.Length - 1) + "\n";
                    }
                    sbLinhas.Append(sAux);
                }
                TextBoxLerSaidas.Text = sbLinhas.ToString();
            }

        }
        catch
        {
        }
    }

    //Retorna o valor mínimo de coluna do campo especificado
    private double Minimo(String sTextBox, int nColuna)
    {
        double nRetorno = 0;
        try
        {
            if (sTextBox.Trim() != "")
            {
                ArrayList alAux = new ArrayList();
                ArrayList alLinhas = StringToArray(sTextBox, "\n", 1);
                for (int nLin = 0; nLin <= alLinhas.Count - 1; nLin++)
                {
                    if (alLinhas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunas = StringToArray(alLinhas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunas.Count - 1; nCol++)
                        {
                            if (nCol == nColuna)
                            {
                                alAux.Add(alColunas[nCol].ToString());
                            }
                        }
                    }
                }
                alAux.Sort();
                if (DropDownListSeparador.SelectedValue == "Ponto")
                {
                    nRetorno = Convert.ToDouble(alAux[0].ToString().Replace(",", "."));
                }
                else
                {
                    nRetorno = Convert.ToDouble(alAux[0].ToString().Replace(".", ","));
                }
            }
        }
        catch
        {
        }
        return (nRetorno);
    }

    //Retorna o valor máximo de coluna do campo especificado
    private double Maximo(String sTextBox, int nColuna)
    {
        double nRetorno = 0;
        try
        {
            if (sTextBox.Trim() != "")
            {
                ArrayList alAux = new ArrayList();
                ArrayList alLinhas = StringToArray(sTextBox, "\n", 1);
                for (int nLin = 0; nLin <= alLinhas.Count - 1; nLin++)
                {
                    if (alLinhas[nLin].ToString().Trim() != "")
                    {
                        ArrayList alColunas = StringToArray(alLinhas[nLin].ToString().Trim(), ";", 1);
                        for (int nCol = 0; nCol <= alColunas.Count - 1; nCol++)
                        {
                            if (nCol == nColuna)
                            {
                                alAux.Add(alColunas[nCol].ToString());
                            }
                        }
                    }
                }
                alAux.Sort();
                if (DropDownListSeparador.SelectedValue == "Ponto")
                {
                    nRetorno = Convert.ToDouble(alAux[alAux.Count - 1].ToString().Replace(",", "."));
                }
                else
                {
                    nRetorno = Convert.ToDouble(alAux[alAux.Count - 1].ToString().Replace(".", ","));
                }
            }
        }
        catch
        {
        }
        return (nRetorno);
    }

    //Obtém os valores mínimos e máximos de cada coluna dos campos de entrada e saída
    private void MinMax()
    {
        try
        {
            if (LabelEntradasColunas.Text.Trim() == "0")
            {
                ButtonLer_Click(null, null);
            }

            String sE = "";
            for (int c = 0; c <= Convert.ToInt32(LabelEntradasColunas.Text) - 1; c++)
            {
                sE = sE + Minimo(TextBoxLerEntradas.Text, c) + ";";
            }
            sE = sE.Substring(0, sE.Length - 1);
            TextBoxEntradasMin.Text = sE;

            sE = "";
            for (int c = 0; c <= Convert.ToInt32(LabelEntradasColunas.Text) - 1; c++)
            {
                sE = sE + Maximo(TextBoxLerEntradas.Text, c) + ";";
            }
            sE = sE.Substring(0, sE.Length - 1);
            TextBoxEntradasMax.Text = sE;

            String sS = "";
            for (int c = 0; c <= Convert.ToInt32(LabelSaidasColunas.Text) - 1; c++)
            {
                sS = sS + Minimo(TextBoxLerSaidas.Text, c) + ";";
            }
            sS = sS.Substring(0, sS.Length - 1);
            TextBoxSaidaMin.Text = sS;

            sS = "";
            for (int c = 0; c <= Convert.ToInt32(LabelSaidasColunas.Text) - 1; c++)
            {
                sS = sS + Maximo(TextBoxLerSaidas.Text, c) + ";";
            }
            sS = sS.Substring(0, sS.Length - 1);
            TextBoxSaidaMax.Text = sS;
        }
        catch
        {
        }
    }

    //Pesquisa substring em string por intervalo de palavras chaves.
    private string PesquisarTXT(String pTexto, String pChave, string pFinal)
    {
        String sRetorno = "";
        try
        {
            int nPosicaoInicial = pTexto.IndexOf(pChave);
            if (nPosicaoInicial != 0)
            {
                String sOcorrencia = pTexto.Substring(nPosicaoInicial);
                sOcorrencia = sOcorrencia.Replace(pChave, "");
                int nPosicaoFinal = sOcorrencia.IndexOf(pFinal);
                sOcorrencia = sOcorrencia.Substring(0, nPosicaoFinal);
                sRetorno = sOcorrencia.Trim();
            }
        }
        catch
        {
        }
        return (sRetorno.Trim().Replace("<BR>", "").Replace("<br>", ""));
    }

    //Pesquisa substring em string por máscara.
    private string PesquisarMascara(String pTexto, String pMascara)
    {
        String sRetorno = "";
        try
        {
            int nTamanho = pMascara.Length;
            for (int i = 0; i <= pTexto.Length - 1; i++)
            {
                String sCadeia = pTexto.Substring(i, nTamanho);
                for (int j = 0; j <= sCadeia.Length - 1; j++)
                {
                    if (pMascara.Substring(j, 1) == "9")
                    {
                        if (Char.IsNumber(sCadeia, j))
                        {
                            sRetorno = sRetorno + sCadeia.Substring(j, 1);
                        }
                        else
                        {
                            sRetorno = "";
                            break;
                        }
                    }
                    else if (pMascara.Substring(j, 1) == "A")
                    {
                        if ((Char.IsLetter(sCadeia, j)) && (Char.IsUpper(sCadeia, j)))
                        {
                            sRetorno = sRetorno + sCadeia.Substring(j, 1);
                        }
                        else
                        {
                            sRetorno = "";
                            break;
                        }
                    }
                    else
                    {
                        if (sCadeia.Substring(j, 1) == pMascara.Substring(j, 1))
                        {
                            sRetorno = sRetorno + sCadeia.Substring(j, 1);
                        }
                        else
                        {
                            sRetorno = "";
                            break;
                        }
                    }
                }
                if (sRetorno != "")
                {
                    break;
                }
            }
        }
        catch
        {
        }
        return (sRetorno.Trim());
    }

    //Pesquisa substring em string por tamanho da string.
    private string PesquisarTamanho(String pTexto, String pTipo, int pTamanho)
    {
        String sRetorno = "";
        try
        {
            for (int i = 0; i <= pTexto.Length - 1; i++)
            {
                String sCadeia = pTexto.Substring(i, pTamanho - 1);
                for (int j = 0; j <= sCadeia.Length - 1; j++)
                {
                    if (pTipo == "N")
                    {
                        if (Char.IsNumber(sCadeia, j))
                        {
                            sRetorno = sRetorno + sCadeia.Substring(j, 1);
                        }
                        else
                        {
                            sRetorno = "";
                            break;
                        }
                    }
                }
                if (sRetorno != "")
                {
                    break;
                }
            }
        }
        catch
        {
        }
        return (sRetorno.Trim());
    }

    //Transforma string em array.
    private static ArrayList StringToArray(string pString, string pCaracterQuebra, int pRetorno)
    {
        int nRetorno = 0;
        int nInicio = 0;
        int nQtdeChar = 0;
        string sAux = "";
        if (pRetorno == 0)
        {
            nRetorno = 2;
        }
        else
        {
            nRetorno = pRetorno;
        }
        ArrayList alTmp = new ArrayList();
        for (int I = 0; I <= pString.Length - 1; I++)
        {
            nQtdeChar++;
            if (pString.Substring(I, 1) == pCaracterQuebra)
            {
                sAux = pString.Substring(nInicio, nQtdeChar - nRetorno);
                nQtdeChar = 0;
                nInicio = I + 1;
                alTmp.Add(sAux);
            }
        }
        sAux = pString.Substring(nInicio, nQtdeChar);
        alTmp.Add(sAux);
        return (alTmp);
    }


    //Calculo do Erro Médio Percentual Absoluto
    private static double CalculaEMPA(string pReal, string pPrevisto)
    {
        double nRetorno = 0;
        try
        {

            //def calculaerro(Real, Previsto):
            //erroabsoluto = 0
            //n = Real.size
            //nLinhas = len(Real)
            //nColunas = len(Real[0])
            //for i in range(nLinhas):
            //for j in range(nColunas):
            //e = abs(Real[i][j] - Previsto[i][j]) / abs(Real[i][j])
            //erroabsoluto += e
            //erromedioabsoluto = erroabsoluto * 100 / n
            //return erromedioabsoluto
        }
        catch
        {
        }
        return (nRetorno);
    }

}