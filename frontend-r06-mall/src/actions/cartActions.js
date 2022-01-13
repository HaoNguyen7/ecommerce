import Axios from 'axios';
import { CART_ADD_ITEM, CART_REMOVE_ITEM, CART_SAVE_SHIPPING_ADDRESS } from '../constants/cartConstants';

export const addToCart = (productId, qty) => async (dispatch, getState) => {
	//const data = await Axios.get(`https://localhost:5001/api/Product/${productId}`);
	const { data } = await Axios.get('https://localhost:5001/api/Product/3aa85f64-5717-4562-b3fc-2c963f66afa6');
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
			shopId: cuaHang.cuaHangId, //shop= data.cuaHang la 1 object chua data cua cua hang gom cuaHangId, tenCuaHang, moTa,...
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
