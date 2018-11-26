import config from '../init/config'

export default {
  isLocalApp () {
    return config.local
  }
}
// export default function (Vue) {
//   Vue.cfg = {
//     isLocalApp () {
//       return config.local
//     }
//   }
//   Object.defineProperties(Vue.prototype, {
//     cfg: {
//       get: () => {
//         return Vue.cfg
//       }
//     }
//   })
// }
