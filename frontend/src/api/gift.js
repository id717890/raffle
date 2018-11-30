import Vue from 'vue'

export default {
  getGiftDraw: () => {
    return Vue.$http.get('api/giftdraw').then((x) => {
      return x
    }).catch(error => {
      return error
    })
  }
}
