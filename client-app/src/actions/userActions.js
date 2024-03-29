import { USER_SIGNIN_FAIL, USER_SIGNIN_REQUEST, USER_SIGNIN_SUCCESS, USER_SIGNOUT } from '../constants/userConstants';

export const signin = (email, id) => async (dispatch) => {
	dispatch({ type: USER_SIGNIN_REQUEST, payload: { email, id } });
	try {
		//lay data user truyen ve
		//const { data } = await Axios.post('https://localhost:5001/Accounts/Login', { email, password });
		const data = { email, id };
		dispatch({ type: USER_SIGNIN_SUCCESS, payload: data });
		localStorage.setItem('userInfo', JSON.stringify(data));
	} catch (error) {
		dispatch({
			type: USER_SIGNIN_FAIL,
			payload: error.response && error.response.data.message ? error.response.data.message : error.message
		});
	}
};
export const signout = () => (dispatch) => {
	localStorage.removeItem('userInfo');
	localStorage.removeItem('cartItems');
	dispatch({ type: USER_SIGNOUT });
};
