import Axios from 'axios';
import {
	CART_ADD_ITEM,
	CART_EMPTY,
	CART_REMOVE_ITEM,
	CART_SAVE_PAYMENT_METHOD,
	CART_SAVE_SHIPPING_ADDRESS
} from '../constants/cartConstants';

export const addToCart = (productId, qty) => async (dispatch, getState) => {
	//const data = await Axios.get(`https://localhost:5001/api/Product/${productId}`);
	const { data } = await Axios.get(`https://localhost:5001/api/Product/${productId}`);
	const { cuaHang } = data;
	console.log('cart action');
	console.log('data:', data);
	console.log('cua hang:', cuaHang);
	dispatch({
		type: CART_ADD_ITEM,
		payload: {
			//contain product
			name: data.tenSanPham,
			image: data.image,
			price: data.donGia,
			countInStock: data.tonKho,
			product: data.sanPhamId,
			qty,
			shopId: cuaHang.cuaHangId,
			shopName: cuaHang.tenCuaHang
		}
	});
	localStorage.setItem('cartItems', JSON.stringify(getState().cart.cartItems)); //refesh trang ko mat data trong gi hang-redux
};

export const removeFromCart = (productId) => (dispatch, getState) => {
	dispatch({ type: CART_REMOVE_ITEM, payload: productId });
	localStorage.setItem('cartItems', JSON.stringify(getState().cart.cartItems)); //refesh trang ko mat data trong gi hang-redux
};

export const saveShippingAddress = (data) => (dispatch) => {
	dispatch({ type: CART_SAVE_SHIPPING_ADDRESS, payload: data });
	localStorage.setItem('shippingAddress', JSON.stringify(data));
};

export const savePaymentMethod = (data) => (dispatch) => {
	dispatch({ type: CART_SAVE_PAYMENT_METHOD, payload: data });
};

export const emptyCart = () => (dispatch) => {
	dispatch({ type: CART_EMPTY });
	localStorage.removeItem('cartItems');
};
