import { useState } from "react";
import { Link } from "react-router-dom";
import { useAuth } from "../context/AuthContext";
import { createRequest } from "../api/apiClient";

function RaiseRequest() {
    const { user, logout } = useAuth();
    const [description, setDescription] = useState("");
    const [details, setDetails] = useState("");
    const [newRequestId, setNewRequestId] = useState(null);
    const [error, setError] = useState("");
    const [submitting, setSubmitting] = useState(false);

    const handleSave = async (e) => {
        e.preventDefault();
        setError("");
        setSubmitting(true);
        try {
            const payload = {
                requestId: 0,
                description,
                details,
                raisedBy: user.userName,
                raisedOn: new Date().toISOString(),
                justification: "",
                reqStatus: 0,
            };
            const response = await createRequest(payload);
            setNewRequestId(response.data.requestId);
            setDescription("");
            setDetails("");
        } catch {
            setError("Unable to save the request. Please check the details and try again.");
        } finally {
            setSubmitting(false);
        }
    };

    return (
        <div className="app-shell">
            <div className="top-banner">
                <span className="logout-link" onClick={logout}>
                    Logout
                </span>
                <h2>Your One Stop Web Site For All Service Requests!</h2>
            </div>

            <div className="page-content">
                <h3>Welcome {user?.userName}</h3>
                <h4>Raise New Request</h4>

                <form onSubmit={handleSave} style={{ maxWidth: 420 }}>
                    <div className="form-row">
                        <label htmlFor="description">Description</label>
                        <input
                            id="description"
                            type="text"
                            value={description}
                            onChange={(e) => setDescription(e.target.value)}
                            maxLength={50}
                            required
                        />
                    </div>
                    <div className="form-row">
                        <label htmlFor="details">Details</label>
                        <textarea
                            id="details"
                            value={details}
                            onChange={(e) => setDetails(e.target.value)}
                            maxLength={100}
                            rows={3}
                            required
                        />
                    </div>
                    {error && <div className="error-text">{error}</div>}
                    <button type="submit" className="btn" disabled={submitting}>
                        {submitting ? "Saving..." : "Save"}
                    </button>
                </form>

                {newRequestId != null && (
                    <div className="success-text">
                        Request Added Successfully. Your request Id is {newRequestId}
                    </div>
                )}

                <div style={{ marginTop: 16 }}>
                    <Link to="/home">Back to List</Link>
                </div>
            </div>
        </div>
    );
}

export default RaiseRequest;