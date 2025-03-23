import { useDispatch } from "react-redux";
import { logout } from "../slices/userSlice";
import { useRouter } from "next/navigation";

export default function Dashboard(){
    const router = useRouter();
    const dispatch = useDispatch();

    return(
        <div>
            <button onClick={() => {
                dispatch(logout());
                router.push("/");
            }}>Log out</button>
        </div>
    )
}