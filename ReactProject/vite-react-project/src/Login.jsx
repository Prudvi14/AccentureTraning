function Login(){
    return (
    <div>
      <form>
        <div>
          <label>Username: </label>
          <input
            type="text"
          />
        </div>
        <div>
          <label>Password: </label>
          <input
            type="password"
          />
        </div>
        <button type="submit">Login</button>
      </form>
    </div>
  );
}
export default Login