<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NN.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Neural Network</title>
</head>
<body>
    <form id="formNN" runat="server">
    <div>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: left;" colspan="10">
                    <asp:Label ID="LabelMensagem" runat="server" Font-Bold="True" ForeColor="Red"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelHiperparametros" runat="server" Font-Bold="True" Text="Hiperparâmetros:"></asp:Label>
                    <br />
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelEntrada" runat="server" Font-Bold="True" Text="NºEntradas"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxEntrada" runat="server" Width="40px" 
                        ToolTip="Número de neurônios da camada de entrada" Font-Names="Courier New">1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEntradas" runat="server" ControlToValidate="TextBoxEntrada"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvEntradas" runat="server" ControlToValidate="TextBoxEntrada"
                        Display="Dynamic" ErrorMessage="1..50" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="50" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelEscondida" runat="server" Font-Bold="True" Text="NºEscondidas"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxEscondida" runat="server" Width="40px" 
                        ToolTip="Número de neurônios da camada escondida (intermediária)" 
                        Font-Names="Courier New">3</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvEscondida" runat="server" ControlToValidate="TextBoxEscondida"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvEscondida" runat="server" ControlToValidate="TextBoxEscondida"
                        Display="Dynamic" ErrorMessage="1..10" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="10" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelSaida" runat="server" Font-Bold="True" Text="NºSaídas"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxSaida" runat="server" Width="40px" 
                        ToolTip="Número de neurônios da camada de saída" Font-Names="Courier New">1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSaida" runat="server" ControlToValidate="TextBoxSaida"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvSaida" runat="server" ControlToValidate="TextBoxSaida"
                        Display="Dynamic" ErrorMessage="1..50" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="50" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelCiclos" runat="server" Font-Bold="True" Text="NºCiclos"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxCiclos" runat="server" Width="40px" 
                        ToolTip="Número de ciclos (épocas)" Font-Names="Courier New">1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvCiclos" runat="server" ControlToValidate="TextBoxCiclos"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvCiclos" runat="server" ControlToValidate="TextBoxCiclos"
                        Display="Dynamic" ErrorMessage="1..5000" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="5000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelExemplos" runat="server" Font-Bold="True" Text="NºExemplos"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxExemplos" runat="server" Width="50px" 
                        ToolTip="Número de exemplos (treinamentos)" Font-Names="Courier New">1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvExemplos" runat="server" ControlToValidate="TextBoxExemplos"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvExemplos" runat="server" ControlToValidate="TextBoxExemplos"
                        Display="Dynamic" ErrorMessage="1..100000" Font-Bold="True" 
                        ForeColor="Red" MinimumValue="1"
                        MaximumValue="100000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelTaxaAprendizagem" runat="server" Font-Bold="True" Text="Aprendizagem"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxTaxaAprendizagem" runat="server" Width="40px" 
                        ToolTip="Taxa de aprendizagem (alfa)" Font-Names="Courier New">0.5</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvTaxaAprendizagem" runat="server" ControlToValidate="TextBoxTaxaAprendizagem"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelSemente" runat="server" Font-Bold="True" Text="Semente"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxSemente" runat="server" Width="40px" 
                        ToolTip="Valor de inicialização dos pesos" Font-Names="Courier New">1315</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvSemente" runat="server" ControlToValidate="TextBoxSemente"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvSemente" runat="server" ControlToValidate="TextBoxSemente"
                        Display="Dynamic" ErrorMessage="1..2000" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="2000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelDecimais" runat="server" Font-Bold="True" Text="Decimais"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxDecimais" runat="server" Width="40px" 
                        ToolTip="Qtde de decimais para exibição" Font-Names="Courier New">4</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvDecimais" runat="server" ControlToValidate="TextBoxDecimais"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvDecimais" runat="server" ControlToValidate="TextBoxDecimais"
                        Display="Dynamic" ErrorMessage="1..15" Font-Bold="True" ForeColor="Red" MinimumValue="1"
                        MaximumValue="15" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelAtiva" runat="server" Font-Bold="True" Text="Ativação"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListAtivacao" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListAtivacao_SelectedIndexChanged" 
                        ToolTip="f(x)=1/(1+e^(-x)) | f'(x)=f(x)(1-f(x))" Font-Names="Courier New">
                        <asp:ListItem>Linear</asp:ListItem>
                        <asp:ListItem>Degrau</asp:ListItem>
                        <asp:ListItem Selected="True">Sigmóide</asp:ListItem>
                        <asp:ListItem>Hiperbólica</asp:ListItem>
                        <asp:ListItem>ReLu</asp:ListItem>
                        <asp:ListItem>Leaky ReLu</asp:ListItem>
                        <asp:ListItem>Soft Max</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelFuncaoCusto" runat="server" Font-Bold="True" Text="Custo"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListFuncaoCusto" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListFuncaoCusto_SelectedIndexChanged" 
                        ToolTip="Função Custo: Utilizada para fazer a rede aprender" 
                        Font-Names="Courier New">
                        <asp:ListItem>EC</asp:ListItem>
                        <asp:ListItem>L1</asp:ListItem>
                        <asp:ListItem Selected="True">L2</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelDesempenho" runat="server" Font-Bold="True" Text="Desempenho"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListDesempenho" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListDesempenho_SelectedIndexChanged" 
                        ToolTip="Avaliação de desempenho" Font-Names="Courier New">
                        <asp:ListItem Selected="True"></asp:ListItem>
                        <asp:ListItem>MSE</asp:ListItem>
                        <asp:ListItem>MAE</asp:ListItem>
                        <asp:ListItem>MAPE</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelArquitetura" runat="server" Font-Bold="True" Text="Arquitetura"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListArquitetura" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListArquitetura_SelectedIndexChanged" 
                        ToolTip="Arquitetura da rede" Font-Names="Courier New">
                        <asp:ListItem Selected="True">MLP</asp:ListItem>
                        <asp:ListItem>CNN</asp:ListItem>
                        <asp:ListItem>RNN</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelOtimizacao" runat="server" Font-Bold="True" Text="Otimização"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListOtimizacao" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListOtimizacao_SelectedIndexChanged" 
                        ToolTip="Algoritmo de otimização" Font-Names="Courier New">
                        <asp:ListItem Selected="True">Momentum</asp:ListItem>
                        <asp:ListItem>Adagrad</asp:ListItem>
                        <asp:ListItem>RMSprop</asp:ListItem>
                        <asp:ListItem>Adadelta</asp:ListItem>
                        <asp:ListItem>Nesterov</asp:ListItem>
                        <asp:ListItem>Adam</asp:ListItem>
                        <asp:ListItem>Adamax</asp:ListItem>
                        <asp:ListItem>AMSGrad</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelMomento" runat="server" Font-Bold="True" Text="Momento"></asp:Label>
                    <br />
                    <asp:TextBox ID="TextBoxMomento" runat="server" Width="40px" 
                        ToolTip="Taxa de momento (beta)" Font-Names="Courier New">0.1</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvMomento" runat="server" ControlToValidate="TextBoxMomento"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelAjuste" runat="server" Font-Bold="True" Text="Ajuste"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListAjuste" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListAjuste_SelectedIndexChanged" 
                        ToolTip="Forma de ajuste" Font-Names="Courier New">
                        <asp:ListItem Selected="True">Online</asp:ListItem>
                        <asp:ListItem>Batch</asp:ListItem>
                        <asp:ListItem>Minibatch</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <asp:Label ID="LabelDimensao" runat="server" Font-Bold="True" Text="Dimensão"></asp:Label>
                    <br />
                    <asp:DropDownList ID="DropDownListDimensao" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListDimensao_SelectedIndexChanged" 
                        ToolTip="Dimensão da rede" Font-Names="Courier New">
                        <asp:ListItem Selected="True">SNN</asp:ListItem>
                        <asp:ListItem>DNN</asp:ListItem>
                    </asp:DropDownList>
                </td>
                <td style="border-right-style: solid; border-right-width: 1px; border-right-color: #000000;
                    vertical-align: top; text-align: left;" width="5%">
                    <br />
                </td>
                <td style="vertical-align: top; text-align: left;" width="100%">
                    <br />
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: left; border-top-style: solid; border-top-width: 1px;
                    border-top-color: #000000;" width="100%">
                    <asp:Button ID="ButtonLimpar" runat="server" Text="Limpar" Font-Bold="True" OnClick="ButtonLimpar_Click"
                        Width="60px" ToolTip="Reinicializa dados para um novo treinamento" />
                    <asp:Button ID="ButtonLer" runat="server" Text="Ler" Font-Bold="True" OnClick="ButtonLer_Click"
                        Width="60px" 
                        ToolTip="Lê dados de entrada/saída para preenchimento das matrizes" 
                        Visible="False" />
                    <asp:Button ID="ButtonTreinar" runat="server" Text="Treinar" Font-Bold="True" OnClick="ButtonTreinar_Click"
                        Width="60px" ToolTip="Inicia o treinamento da Rede Neural Artificial (RNA) modelo MLP" />
                    <asp:DropDownList ID="DropDownListSeparador" runat="server" AutoPostBack="True" 
                        onselectedindexchanged="DropDownListAtivacao_SelectedIndexChanged" 
                        ToolTip="Separador de decimais" Font-Names="Courier New">
                        <asp:ListItem Selected="True">Ponto</asp:ListItem>
                        <asp:ListItem>Vírgula</asp:ListItem>
                    </asp:DropDownList>
                    <asp:Label ID="LabelLimite" runat="server" Font-Bold="True" Text="Limite" 
                        ForeColor="Red" Visible="False"></asp:Label>
                    <asp:TextBox ID="TextBoxLimite" runat="server" Width="50px" ToolTip="Limite máximo de linhas da matriz (força saída do treinamento)"
                        Font-Bold="True" ForeColor="Red" Visible="False" Enabled="False">100</asp:TextBox>
                    <asp:RequiredFieldValidator ID="rfvQuebra" runat="server" ControlToValidate="TextBoxLimite"
                        Display="Dynamic" ErrorMessage="*" Font-Bold="True" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="rvQuebra" runat="server" ControlToValidate="TextBoxLimite"
                        Display="Dynamic" ErrorMessage="1..100000" Font-Bold="True" 
                        ForeColor="Red" MinimumValue="1"
                        MaximumValue="100000" SetFocusOnError="True" Type="Integer"></asp:RangeValidator>
                    <asp:Label ID="LabelLinhasTit" runat="server" Font-Bold="True" 
                        Text="Qtd.Linhas" ForeColor="Red" Visible="False"></asp:Label>
                    <asp:Label ID="LabelLinhas" runat="server" Font-Bold="True" Text="0" ToolTip="Número de linhas"
                        ForeColor="Red" Visible="False"></asp:Label>
                    <asp:CheckBox ID="CheckBoxEMPA" runat="server" Checked="True" Font-Bold="True" 
                        ForeColor="Red" Text="EMPA:" ToolTip="Erro Médio Percentual Absoluto" />
                    <asp:Label ID="LabelTempo" runat="server" Font-Bold="True" 
                        ToolTip="Tempo do processamento"></asp:Label>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: left;">
                    <asp:CheckBox ID="CheckBoxCiclos" runat="server" Font-Bold="True" Text="Ciclos" 
                        ToolTip="Ciclos realizados" Checked="True" />
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:CheckBox ID="CheckBoxExemplos" runat="server" Font-Bold="True" 
                        Text="Exemplos" ToolTip="Exemplos realizados" Checked="True" />
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:CheckBox ID="CheckBoxCusto" runat="server" Font-Bold="True" Text="EMQ" 
                        ToolTip="Erro Médio Quadrático" Checked="True" />
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:CheckBox ID="CheckBoxErro" runat="server" Font-Bold="True" Text="Erro" 
                        ToolTip="Erro calculado" Checked="True" />
                </td>
                <td style="vertical-align: top; text-align: left;" width="100%">
                    <asp:CheckBox ID="CheckBoxTreinamento" runat="server" Font-Bold="True" 
                        Text="Treinamento" ToolTip="Resultado do treinamento" />
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left;">
                    <asp:TextBox ID="TextBoxSaidaCiclos" runat="server" Rows="20" TextMode="MultiLine"
                        ToolTip="Ciclos realizados" Width="90px" Font-Names="Courier New"></asp:TextBox>
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:TextBox ID="TextBoxSaidaExemplos" runat="server" Rows="20" TextMode="MultiLine"
                        ToolTip="Exeemplos realizados" Width="100px" Font-Names="Courier New"></asp:TextBox>
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:TextBox ID="TextBoxSaidaEMQs" runat="server" Rows="20" TextMode="MultiLine"
                        ToolTip="Função Custo: Erro Médio Quadrático (EMC)"  
                        Width="90px" Font-Names="Courier New"></asp:TextBox>
                </td>
                <td style="vertical-align: top; text-align: left;">
                    <asp:TextBox ID="TextBoxSaidaErros" runat="server" Rows="20" TextMode="MultiLine"
                        ToolTip="Erros obtidos" Width="350px" Font-Names="Courier New"></asp:TextBox>
                </td>
                <td style="vertical-align: top; text-align: left;" width="100%">
                    <asp:TextBox ID="TextBoxSaidaTreinamentos" runat="server" Rows="20" TextMode="MultiLine"
                        ToolTip="Treinamento da rede neural artificial"  
                        Width="100%" Font-Names="Courier New"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: left;" width="50%">
                    <asp:Label ID="LabelEntradasTit" runat="server" Font-Bold="True" Text="Entradas (x)"></asp:Label>
                </td>
                <td style="vertical-align: top; text-align: left;" width="50%">
                    <asp:Label ID="LabelSaidaTit" runat="server" Font-Bold="True" Text="Saídas (y)"></asp:Label>
                </td>
            </tr>
            <tr>
                <td style="vertical-align: top; text-align: left;" width="50%">
                    <asp:TextBox ID="TextBoxLerEntradas" runat="server" Rows="10" TextMode="MultiLine"
                        
                        ToolTip="Insira ou cole aqui os dados de entrada separados por ponto-e-vírgula" Width="100%" 
                        Font-Names="Courier New"></asp:TextBox>
                </td>
                <td style="vertical-align: top; text-align: left;" width="50%">
                    <asp:TextBox ID="TextBoxLerSaidas" runat="server" Rows="10" TextMode="MultiLine"
                        
                        ToolTip="Insira ou cole aqui os dados de saída separados por ponto-e-vírgula" Width="100%" 
                        Font-Names="Courier New"></asp:TextBox>
                </td>
            </tr>
        </table>
        <table style="width: 100%;">
            <tr>
                <td style="vertical-align: top; text-align: left;" width="100%">
                    <asp:Label ID="LabelAutoria" runat="server" Font-Bold="False" Text="alvarofpinheiro (09/10/2019)"
                        ToolTip="Autoria"></asp:Label>
                    <asp:HyperLink ID="hub" runat="server" 
                        NavigateUrl="https://github.com/alvarofpinheiro/NeuralNetwork" Target="_blank" 
                        ToolTip="fontes">https://github.com/alvarofpinheiro/NeuralNetwork</asp:HyperLink>
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>
