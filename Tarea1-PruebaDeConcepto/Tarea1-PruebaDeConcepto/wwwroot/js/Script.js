async function MostrarEmpleado() {
    try {
        //const response = await fetch('https://localhost:5001/api/storedprocedures/mostrarEmpleados');
        //const resultado = await response.json();

        const tbody = document.querySelector("#datosTabla");

        for (let i = 0; i < 1; i++) { //En donde 1 se va resultado.lenght u otro para poder la cantidad de datos en tabla
            //console.log(resultado[i]);

            const trInicio = document.createElement("tr");

            let tdId = document.createElement("td");
            tdId.textContent = "Aqui va como sea que consiga el dato de resultado"
            trInicio.appendChild(tdId);

            let tdNombre = document.createElement("td");
            tdNombre.textContent = "Aqui va como sea que consiga el dato de resultado"
            trInicio.appendChild(tdNombre);

            let tdSaldo = document.createElement("td");
            tdSaldo.textContent = "Aqui va como sea que consiga el dato de resultado"
            trInicio.appendChild(tdSaldo);

            tbody.appendChild(trInicio);
        }

    } catch (error) {
        console.error('Error:', error);
    }
}

//Acciones en html
document.addEventListener('DOMContentLoaded', function () {
    const button = document.getElementById('irInsertarEmpleado');
    button.addEventListener('click', function () {
        window.location.href = 'InsertarEmpleado.html';
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const button = document.getElementById('accionInsertar');
    button.addEventListener('click', function () {
        const nombre = document.getElementById('nombre').innerText;
        const salario = document.getElementById('salario').innerText;
        insertarEmpleado(nombre, salario)
    });
});

document.addEventListener('DOMContentLoaded', function () {
    const button = document.getElementById('regresarInsertarVista');
    button.addEventListener('click', function () {
        window.location.href = 'VistaUsuario.html';
    });
});

function insertarEmpleado(nombre, salario) {
    fetch('https://localhost:5001/api/Empleado/Insertar', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            nombre: nombre,
            salario: salario
        }),
    }).then(respuesta => respuesta.json())
        .then(datos => console.log(datos))
}
