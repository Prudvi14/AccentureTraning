import { useEffect, useState } from "react";
import { getStudents, createStudent, updateStudent, deleteStudent } from "./api/studentApi";
import StudentForm from "./components/StudentForm";
import StudentList from "./components/StudentList";
import "./App.css";

export default function App() {
  const [students, setStudents] = useState([]);
  const [loading, setLoading] = useState(true);
  const [error, setError] = useState("");

  const [editingStudent, setEditingStudent] = useState(null);
  const [isSaving, setIsSaving] = useState(false);
  const [deletingId, setDeletingId] = useState(null);

  // READ — load the list once when the app mounts
  useEffect(() => {
    let cancelled = false;

    async function load() {
      try {
        setLoading(true);
        const data = await getStudents();
        if (!cancelled) setStudents(data);
      } catch (err) {
        if (!cancelled) setError(err.message);
      } finally {
        if (!cancelled) setLoading(false);
      }
    }

    load();
    return () => {
      cancelled = true;
    };
  }, []);

  // CREATE
  async function handleCreate(newStudent) {
    setIsSaving(true);
    setError("");
    try {
      const created = await createStudent(newStudent);
      // JSONPlaceholder always echoes id: 11 for new posts since it doesn't
      // really persist data, so we generate a locally-unique id instead to
      // avoid key collisions if you add more than one student.
      const localId = Date.now();
      setStudents((prev) => [...prev, { ...newStudent, id: created.id ?? localId }]);
    } catch (err) {
      setError(err.message);
    } finally {
      setIsSaving(false);
    }
  }

  // UPDATE
  async function handleUpdate(id, updatedFields) {
    setIsSaving(true);
    setError("");
    try {
      await updateStudent(id, updatedFields);
      setStudents((prev) =>
        prev.map((s) => (s.id === id ? { ...s, ...updatedFields } : s))
      );
      setEditingStudent(null);
    } catch (err) {
      setError(err.message);
    } finally {
      setIsSaving(false);
    }
  }

  // DELETE
  async function handleDelete(id) {
    setDeletingId(id);
    setError("");
    try {
      await deleteStudent(id);
      setStudents((prev) => prev.filter((s) => s.id !== id));
      if (editingStudent?.id === id) setEditingStudent(null);
    } catch (err) {
      setError(err.message);
    } finally {
      setDeletingId(null);
    }
  }

  return (
    <div className="app-shell">
      <header className="app-header">
        <h1>Student List</h1>
      </header>

      {error && <div className="banner banner-error">{error}</div>}

      <main className="app-main">
        <section className="panel">
          <StudentForm
            editingStudent={editingStudent}
            onCreate={handleCreate}
            onUpdate={handleUpdate}
            onCancelEdit={() => setEditingStudent(null)}
            isSaving={isSaving}
          />
        </section>

        <section className="panel panel-wide">
          {loading ? (
            <p className="empty-state">Loading students…</p>
          ) : (
            <StudentList
              students={students}
              onEdit={setEditingStudent}
              onDelete={handleDelete}
              deletingId={deletingId}
            />
          )}
        </section>
      </main>
    </div>
  );
}
