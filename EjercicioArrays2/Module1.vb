Module Module1

    Sub Main()
        '  Implementar un programa que permita realizar lo siguiente: 

        '- Crear dos listas de datos, una para los nombres de alumnos y otra con las calificaciones de los 10 alumnos de una asignatura.
        '- Rellenar los arrays con datos y mostrarlos por pantalla. 
        '- Cálculo y publicación de estadísticas de la clase.

        'Para ello, se deben crear y utilizar los siguientes procedimientos/funciones: 

        Dim listanombres(9) As String
        Dim listanotas(9) As Double
        Dim listadatos() As Double

        listanombres = cargarArrayNombres(listanombres)
        Console.WriteLine("")
        listanotas = cargarArrayNotas(listanotas)
        mostrar(listanombres, listanotas)
        listadatos = calculoDatos(listanotas)
        mostrarEstadisticas(listanombres, listadatos)

        Console.ReadLine()


    End Sub

    '- cargarArrayNombres método que rellena un array con los nombres. Se solicitan por teclado 10 nombres de alumnos y lo devuelve.

    Function cargarArrayNombres(ParamArray lista() As String) As String()

        For i = 0 To lista.Length - 1
            Console.Write("Nombre de alumno " & i + 1 & ": ")
            lista(i) = Console.ReadLine()
        Next

        Return lista
    End Function

    '- cargarArrayNotas: método que rellena un array con las notas de los 10 alumnos y lo devuelve. Las notas deben estar validadas entre 0 10 y también debe aceptar decimales.

    Function cargarArrayNotas(ParamArray lista() As Double) As Double()

        For i = 0 To lista.Length - 1
            Console.Write("Nota de alumno " & i + 1 & ": ")
            lista(i) = Console.ReadLine()
        Next

        Return lista

    End Function

    '- mostrarTodosDatos: recibe por parámetros los dos arrays creados en los puntos anteriores y los muestra por pantalla. Los datos se deben mostrar de la siguiente forma

    'Nombre1 Apellido11 Apellido12 - Nota

    'Nombre2 Apellido21 Apellido22 - Nota

    Sub mostrar(listanom() As String, listanotas() As Double)

        Console.WriteLine("")

        For i = 0 To listanom.Length - 1
            Console.WriteLine(listanom(i) & " - " & listanotas(i))
        Next

    End Sub

    '- calculoDatos recibe como por parámetros el array de notas creado anteriormente. Con estos datos se debe calcular: 
    '       - La nota media de la clase
    '       - La nota máxima de los alumnos
    '       - A quién pertenece dicha nota
    '       - La nota mínima
    '       - A quién pertenece dicha nota
    ' Se debe devolver un array con los cuatro datos calculados. En caso de haber notas repetidas, prevalece el último alumno consultado.

    Function calculoDatos(ParamArray lista() As Double) As Double()

        Dim listadatos(4) As Double
        Dim aux, aux2, media As Double
        Dim sw As Boolean = False
        Dim cont As Integer = lista.Length - 1

        'media
        For i = 0 To lista.Length - 1
            aux = lista(i)
            aux2 = aux2 + aux
        Next

        media = (aux2 / lista.Length)
        listadatos(0) = media

        'nota maxima
        listadatos(1) = lista.Max()

        'de quien es la nota maxima

        While sw = False And cont > 0
            If lista.Max() = lista(cont) Then
                sw = True
            End If
            cont = cont - 1
        End While

        listadatos(2) = cont + 1

        'nota minima
        listadatos(3) = lista.Min()

        'de quien es la nota minima
        sw = False
        cont = lista.Length - 1

        While sw = False And cont > 0
            If lista.Min() = lista(cont) Then
                sw = True
            End If
            cont = cont - 1
        End While

        listadatos(4) = cont + 1

        Return listadatos

    End Function


    '- mostrarEstadisticas recibe como parámetro el array de nombres de alumnos y el array de estadísticas creado en el punto anterior (calculoDatos). 
    'Con esto, muestra por pantalla los datos calculados.

    Sub mostrarEstadisticas(listanom() As String, listadat() As Double)

        Dim x() As String = {"La nota media es: ", "La nota mas alta es: ", "La nota mas alta la ha sacado: ", "La nota mas baja es: ", "La nota mas baja la ha sacado: "}

        Console.WriteLine("")
        For i = 0 To listadat.Length - 1
            If i <> 2 And i <> 4 Then
                Console.WriteLine(x(i) & "" & listadat(i))
            Else
                Console.WriteLine(x(i) & "" & listanom(listadat(i)))

            End If

        Next

    End Sub

End Module
