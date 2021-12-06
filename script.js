const get = async () =>{
    const res =  await fetch('https://localhost:44364/api/Employees');
    const data = await res.json();
    console.log(data);
}

get();