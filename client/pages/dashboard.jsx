import { useRouter } from "next/navigation";
import { useDispatch } from "react-redux";
import { logout } from "../slices/userSlice"; // Импортируем action logout
import withAuth from "../utils/withAuth";

function Dashboard() {
    const router = useRouter();
    const dispatch = useDispatch();

    const handleLogout = async () => {
        try {
            const response = await fetch('http://localhost:5000/api/auth/logout', {
                method: 'POST',
                credentials: 'include',
            });

            if (response.ok) {
                dispatch(logout());
                router.push("/");
            } else {
                console.error("Ошибка при выходе");
            }
        } catch (error) {
            console.error("Ошибка сети:", error);
        }
    };

    return (
        <div>
            <button onClick={handleLogout}>Log out</button>
        </div>
    );
}

export default withAuth(Dashboard);
