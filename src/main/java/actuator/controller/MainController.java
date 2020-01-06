package actuator.controller;

import org.apache.logging.log4j.LogManager;
import org.apache.logging.log4j.Logger;
import org.springframework.boot.web.servlet.error.ErrorController;
import org.springframework.http.HttpEntity;
import org.springframework.http.HttpHeaders;
import org.springframework.http.MediaType;
import org.springframework.stereotype.Controller;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.ResponseBody;
import org.springframework.web.client.RestTemplate;

import javax.servlet.http.HttpServletRequest;

@ResponseBody
@Controller
public class MainController implements ErrorController {
    private static final Logger logger = LogManager.getLogger(MainController.class);

    @RequestMapping("/")
    public String Home(HttpServletRequest http){
        String endpointBasePath = "/actuator"; // run all acturators

        StringBuilder sb = new StringBuilder();

        sb.append("<h2>Sprig Boot Actuator</h2>");
        sb.append("<ul>");

        String host = http.getServerName();
        String contextPath = http.getContextPath();
        String url = "http://" + host + ":8090" + contextPath + endpointBasePath;

        sb.append("<li><a href=").append(url).append("'>").append(url).append("</a></li></ul>");

        return sb.toString();
    }

    @RequestMapping("/shutdown") // run close acturator & close server
    public String closer(){
        HttpHeaders headers = new HttpHeaders();
        headers.add("Accept", MediaType.APPLICATION_JSON_VALUE);
        headers.setContentType(MediaType.APPLICATION_JSON);

        RestTemplate rt = new RestTemplate();
        HttpEntity<String> requestBody = new HttpEntity<>("", headers);
        String e = rt.postForObject("http://localhost:8090/actuator/shutdown", requestBody, String.class);
        return "Result : " + e;
    }

    @RequestMapping("/log4j")
    public String testMethod() {

        logger.trace("trace");
        logger.info("info");
        logger.debug("debug");
        logger.error("error");
        logger.fatal("fatal");
        logger.warn("warn");

        return "Check the Console Logs";
    }

    @RequestMapping("/error")
    public String handleError() {
        return "error";
    }

    @Override
    public String getErrorPath() {
        return "/error";
    }

}