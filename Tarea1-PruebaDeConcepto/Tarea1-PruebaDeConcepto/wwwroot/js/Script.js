console.log("Script.js se ha cargado correctamente.");

//Acciones en html
document.addEventListener("DOMContentLoaded", function () {
    mostrarEmpleado();
    console.log("Script.js se ha cargado correctamente");
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('irInsertarEmpleado');
        button.addEventListener('click', function () {
            window.location.href = 'InsertarEmpleado.html';
            console.log("HEMOS APRETADO EL BOTON")
        });
    }
    catch {
        console.log("Boton no existe")
    }
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('accionInsertar');
        button.addEventListener('click', function () {
            const nombre = document.getElementById('nombre').value;


            const salario = parseFloat(document.getElementById('salario').value);

            insertarEmpleado(nombre, salario)
            console.log("HEMOS APRETADO EL BOTON")
        });
    }
    catch {
        console.log("Boton no existe")    }
});

document.addEventListener('DOMContentLoaded', function () {
    try {
        const button = document.getElementById('regresarInsertarVista');
        button.addEventListener('click', function () {
            window.location.href = 'VistaUsuario.html';
        });
    }
    catch {
        console.log("Boton no existe")
    }
});


// Llamar a stored procedures
function insertarEmpleado(nombre, salario) {
    fetch('https://localhost:5001/api/BDController/InsertarControlador', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify({
            Nombre: nombre,
            Salario: salario
        }),
    }).then(respuesta => respuesta.json())
        .then(datos => console.log(datos))
    console.log("HEMOS REALIZADO EL FETCH")
}


function mostrarEmpleado() {
    try {
        fetch('https://localhost:5001/api/BDController/MostrarControlador')
            .then(respuesta => respuesta.json())  // Convierte la respuesta a JSON
            .then(datos => {
                console.log("Respuesta recibida del servidor:", datos);

                const tbody = document.querySelector("#datosTabla");

                if (datos.length == 0) {
                    const trInicio = document.createElement("tr");
                    const tdNoData = document.createElement("td");
                    tdNoData.colSpan = 3;
                    tdNoData.textContent = "La tabla está vacía.";
                    trInicio.appendChild(tdNoData);
                    tbody.appendChild(trInicio);
                } else {
                    datos.forEach((empleado) => {
                        const trInicio = document.createElement("tr");

                        let tdId = document.createElement("td");
                        tdId.textContent = empleado.id;  // Asume que el campo es 'id'
                        trInicio.appendChild(tdId);

                        let tdNombre = document.createElement("td");
                        tdNombre.textContent = empleado.nombre;  // Asume que el campo es 'nombre'
                        trInicio.appendChild(tdNombre);

                        let tdSaldo = document.createElement("td");
                        tdSaldo.textContent = empleado.salario;  // Asume que el campo es 'salario'
                        trInicio.appendChild(tdSaldo);

                        tbody.appendChild(trInicio);
                    });
                }

            })
            .catch(error => {
                console.error('Error al obtener los datos:', error);
            });
    } catch (error) {
        console.error('Error en el bloque try:', error);
    }
}






