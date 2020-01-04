<template>
  <div class="amap-wrapper">
    <el-amap
      class="amap-box"
      vid="amap-vue"
      :center="center"
      :zoom="zoom"
      :events="MapEvents"
      :amap-manager="amapManager"
    >
      <el-amap-marker
        v-for="(marker, index) in markers"
        :key="index"
        :position="marker.position"
        :vid="index"
      ></el-amap-marker>

      <el-amap-circle
        v-for="(circle,num) in circles"
        :key="num+markers.length+1"
        :center="circle.center"
        :radius="radius"
        :fill-opacity="fillOpacity"
        :strokeWeight="1"
        :events="CircltEvent"
      ></el-amap-circle>
    </el-amap>
  </div>
</template>
<style>
.amap-wrapper {
  width: 500px;
  height: 300px;
}
.amap-logo,
.amap-copyright {
  display: none !important;
}
</style>

<script>
import VueAMap from "vue-amap";
let amapManager = new VueAMap.AMapManager();
export default {
  data() {
    var self = this;
    return {
      amapManager: amapManager,
      center: [120.570682, 31.294826],
      zoom: 18,
      radius: 200,
      fillOpacity: 0.3,
      markers: [
        {
          position: [120.570682, 31.294826]
        }
      ],
      circles: [
        {
          center: [120.570682, 31.294826]
        }
      ],

      CircltEvent: {
        click(e) {
          var zhuobiao = e.lnglat;
          var piont = { position: [zhuobiao.O, zhuobiao.P] };
          self.markers = [];
          self.markers.push(piont);

          piont = { center: [zhuobiao.O, zhuobiao.P] };
          self.circles = [];
          self.circles.push(piont);
        }
      },

      MapEvents: {
        click(e) {
          var zhuobiao = e.lnglat;

          //   let o = amapManager.getMap();

          //   let marker = new AMap.Marker({
          //     position: [zhuobiao.O, zhuobiao.P]
          //   });
          //   console.log(marker);
          //   marker.setMap(o);
          //   console.log(self.markers);

          var piont = { position: [zhuobiao.O, zhuobiao.P] };
          self.markers = [];
          self.markers.push(piont);

          piont = { center: [zhuobiao.O, zhuobiao.P] };
          self.circles = [];
          self.circles.push(piont);
        }
      }
    };
  },
  methods: {},
  mounted: function() {}
};
</script>