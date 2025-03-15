async function MostrarEmpleado() {
    try {
        //const response = await fetch('https://localhost:5001/api/storedprocedures/mostrarEmpleados');
        //const resultado = await response.json();

        const tbody = document.querySelector("#datosTabla");

        for (let i = 0; i < 1; i++) {
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

MostrarEmpleado();