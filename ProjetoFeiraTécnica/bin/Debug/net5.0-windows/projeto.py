import PySimpleGUI as pg
import speech_recognition as sr
from tkinter import messagebox


layout = [
    [pg.Text("PROGRAMA DE RECONHECIMENTO DE VOZ")],
    [pg.Text("CLIQUE NO 'OK' E ESPERE 2 SEGUNDOS PARA COMEÇAR A FALAR")],
    [pg.Text("EXEMPLO: SEGUNDO ANO DE INFORMÁTICA")],
    [pg.Button("OK")]


]

window = pg.Window("PROJETO FEIRA", layout)
lista_palavras = ["primeiro ano de informática","segundo ano de informática","terceiro ano de informática",
                  "primeiro ano de química","segundo ano de química", "terceiro ano de química",
                "primeiro ano de eletrônica","segundo ano de eletrônica","terceiro ano de eletrônica",
                "primeiro ano de análises clínicas","segundo ano de análises clínicas","terceiro ano de análises clínicas",
                "primeiro ano de publicidade","segundo ano de publicidade","terceiro ano de publicidade",
                "primeiro ano de administração","segundo ano de administração","terceiro ano de administração"
]

while True:
    try:
        evento, valores = window.read()
        if evento == pg.WIN_CLOSED:
            break
        elif evento == "OK":
            rec = sr.Recognizer()
            with sr.Microphone() as microfone:
                rec.adjust_for_ambient_noise(microfone)
                audio = rec.listen(microfone)
                tradutor = rec.recognize_google(audio, language="pt-BR")
                if lista_palavras.count(tradutor) == 0:
                    messagebox.showerror("ERRO!", f"A FRASE: '{tradutor}' NÃO E INDENTIFICADA COMO UM CURSO CLIQUE NO 'OK' E REPITA")

                    del tradutor
                    continue
                elif tradutor != "":
                    print(tradutor)
                    window.close()

                '''if tradutor == "informática":
                    retorno3 = messagebox.showinfo("!!!!", "CRIANDO O CAMINHO!!!!")
                    if retorno3 == "ok":
                        imagem = cv2.imread("imgs/pavimento_terreo.jpg")
                        imagem = cv2.resize(imagem, (int(2516/2), int(1259/2)))
                        cv2.imshow("CAMINHO", imagem)'''

    except Exception as erro:

        if str(erro) == "[Errno -9999] Unanticipated host error":
            messagebox.showerror("!!!", "VEJA SE O MICROFONE ESTA CONECTADO DE FORMA CORRETA")
        elif str(erro) == "name 'tradutor' is not defined":
            continue
        else:
            messagebox.showerror("ERROR", erro)