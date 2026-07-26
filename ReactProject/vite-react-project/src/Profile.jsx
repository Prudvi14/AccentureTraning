function Profile() {
  const user = {
    name: 'Prudvi',
    email: 'Prudvi@example.com',
    bio: 'Learning React and Docker!'
  };

  return (
    <div>
      <h1>Profile Page</h1>
      <p>Name: {user.name}</p>
      <p>Email: {user.email}</p>
      <p>Bio: {user.bio}</p>
    </div>
  );
}

export default Profile;