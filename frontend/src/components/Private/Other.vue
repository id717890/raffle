<template>
  <div>
    <form method="POST" action="https://money.yandex.ru/quickpay/confirm.xml">
 
<!--Номер кошелька в системе Яндекс Денег-->
<input type="hidden" name="receiver" value="410016208060232">
 
<!--Название платежа, я не нашел, где этот параметр используется, поэтому просто указал адрес своего сайта (длина 50 символов)-->
<input type="hidden" name="formcomment" value="truemisha.ru">
 
<!--Этот параметр передаёт ID плагина, для того, чтобы скрипту было понятно, что потом отсылать пользователю (длина 64 символа)-->
<input type="hidden" name="label" value="16078">
 
<!--Тип формы, может принимать значения shop (универсальное), donate (благотворительная), small (кнопка)-->
<input type="hidden" name="quickpay-form" value="shop">
 
<!--Назначение платежа, это покупатель видит на сайте Яндекс Денег при вводе платежного пароля (длина 150 символов)-->
<input type="hidden" name="targets" value="Покупка плагина True Instagram Widget на сайте truemisha.ru">
 
<!--Сумма платежа, валюта - рубли по умолчанию-->
<input type="hidden" name="sum" value="2" data-type="number">
 
<!--Должен ли Яндекс запрашивать ФИО покупателя-->
<input type="hidden" name="need-fio" value="false">
 
<!--Должен ли Яндекс запрашивать email покупателя-->
<input type="hidden" name="need-email" value="true">
 
<!--Должен ли Яндекс запрашивать телефон покупателя-->
<input type="hidden" name="need-phone" value="false">
 
<!--Должен ли Яндекс запрашивать адрес покупателя-->
<input type="hidden" name="need-address" value="false">
 
<!--Метод оплаты, PC - Яндекс Деньги, AC - банковская карта-->
<input type="hidden" name="paymentType" value="AC" />
 
<!--Куда перенаправлять пользователя после успешной оплаты платежа-->
<input type="hidden" name="successURL" value="http://localhost:8080">
<button>Оплатить</button> 
</form>
  </div>
</template>

<script>
export default {

}
</script>

<style>

</style>
