export default function StudentList({ students, onEdit, onDelete, deletingId }) {
  if (students.length === 0) {
    return <p className="empty-state">No students yet. Add one using the form.</p>;
  }

  return (
    <table className="student-table">
      <thead>
        <tr>
          <th>Name</th>
          <th>Email</th>
          <th>Age</th>
          <th aria-label="actions"></th>
        </tr>
      </thead>
      <tbody>
        {students.map((student) => (
          <tr key={student.id}>
            <td>{student.name}</td>
            <td>{student.email}</td>
            <td>{student.age}</td>
            <td className="row-actions">
              <button className="btn btn-small" onClick={() => onEdit(student)}>
                Edit
              </button>
              <button
                className="btn btn-small btn-danger"
                onClick={() => onDelete(student.id)}
                disabled={deletingId === student.id}
              >
                {deletingId === student.id ? "Deleting…" : "Delete"}
              </button>
            </td>
          </tr>
        ))}
      </tbody>
    </table>
  );
}
