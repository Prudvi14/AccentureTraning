import { useEffect, useState } from "react";

const emptyForm = { name: "", email: "", age: "" };

// A single form used for BOTH create and edit.
// If `editingStudent` is passed in, the form pre-fills and switches to "update" mode.
export default function StudentForm({ editingStudent, onCreate, onUpdate, onCancelEdit, isSaving }) {
  const [form, setForm] = useState(emptyForm);
  const [errors, setErrors] = useState({});

  // Whenever the parent hands us a student to edit, load it into the form.
  useEffect(() => {
    if (editingStudent) {
      setForm({
        name: editingStudent.name ?? "",
        email: editingStudent.email ?? "",
        age: editingStudent.age ?? "",
      });
    } else {
      setForm(emptyForm);
    }
    setErrors({});
  }, [editingStudent]);

  function handleChange(e) {
    const { name, value } = e.target;
    setForm((prev) => ({ ...prev, [name]: value }));
  }

  function validate() {
    const next = {};
    if (!form.name.trim()) next.name = "Name is required";
    if (!form.email.trim()) next.email = "Email is required";
    else if (!/^\S+@\S+\.\S+$/.test(form.email)) next.email = "Enter a valid email";
    if (!form.age || Number(form.age) <= 0) next.age = "Enter a valid age";
    setErrors(next);
    return Object.keys(next).length === 0;
  }

  function handleSubmit(e) {
    e.preventDefault();
    if (!validate()) return;

    const payload = { ...form, age: Number(form.age) };

    if (editingStudent) {
      onUpdate(editingStudent.id, payload);
    } else {
      onCreate(payload);
      setForm(emptyForm);
    }
  }

  return (
    <form className="student-form" onSubmit={handleSubmit} noValidate>
      <h2>{editingStudent ? "Edit student" : "Add a student"}</h2>

      <div className="field">
        <label htmlFor="name">Name</label>
        <input id="name" name="name" value={form.name} onChange={handleChange} placeholder="Ada Lovelace" />
        {errors.name && <span className="error-text">{errors.name}</span>}
      </div>

      <div className="field">
        <label htmlFor="email">Email</label>
        <input id="email" name="email" value={form.email} onChange={handleChange} placeholder="ada@example.com" />
        {errors.email && <span className="error-text">{errors.email}</span>}
      </div>

      <div className="field">
        <label htmlFor="age">Age</label>
        <input id="age" name="age" type="number" min="1" value={form.age} onChange={handleChange} placeholder="21" />
        {errors.age && <span className="error-text">{errors.age}</span>}
      </div>

      <div className="form-actions">
        <button type="submit" className="btn btn-primary" disabled={isSaving}>
          {isSaving ? "Saving…" : editingStudent ? "Save changes" : "Add student"}
        </button>
        {editingStudent && (
          <button type="button" className="btn btn-ghost" onClick={onCancelEdit} disabled={isSaving}>
            Cancel
          </button>
        )}
      </div>
    </form>
  );
}
