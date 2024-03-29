import Axios from 'axios';
import { CART_EMPTY } from '../constants/cartConstants';
import { ORDER_CREATE_FAIL, ORDER_CREATE_REQUEST, ORDER_CREATE_SUCCESS } from '../constants/orderConstants';

export const createOrder = () => async (dispatch, getState) => {
	//dispatch({ type: ORDER_CREATE_REQUEST, payload: order });
	try {
		//const { data } = await Axios.post('/api/orders', order);
		//dispatch({ type: ORDER_CREATE_SUCCESS, payload: data.order });
		dispatch({ type: CART_EMPTY });
		localStorage.removeItem('cartItems');
	} catch (error) {
		console.log(error);
		// dispatch({
		// 	type: ORDER_CREATE_FAIL,
		// 	payload: error.response && error.response.data.message ? error.response.data.message : error.message
		// });
	}
};
