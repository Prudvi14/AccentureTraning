

const BASE_URL = "https://jsonplaceholder.typicode.com/users";



async function handleResponse(res) {
  if (!res.ok) {
    throw new Error(`Request failed: ${res.status} ${res.statusText}`);
  }
  return res.json();
}

// READ — fetch all students
export async function getStudents() {
  const res = await fetch(BASE_URL);
  const data = await handleResponse(res);
  return data.map((user) => ({
    id: user.id,
    name: user.name,
    email: user.email,
    age: user.age ?? "-",
  }));
}

// CREATE — add a new student
export async function createStudent(student) {
  const res = await fetch(BASE_URL, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
  return handleResponse(res); // JSONPlaceholder echoes the body back + a fake id (usually 11)
}

// UPDATE — edit an existing student
export async function updateStudent(id, student) {
  const res = await fetch(`${BASE_URL}/${id}`, {
    method: "PUT",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(student),
  });
  return handleResponse(res);
}

// DELETE — remove a student
export async function deleteStudent(id) {
  const res = await fetch(`${BASE_URL}/${id}`, { method: "DELETE" });
  if (!res.ok) {
    throw new Error(`Request failed: ${res.status} ${res.statusText}`);
  }
  return true;
}
