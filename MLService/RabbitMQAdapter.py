import pika


def create_channel(host):
    connection = pika.BlockingConnection(pika.ConnectionParameters(host))
    channel = connection.channel()
    return channel


def send_message(channel, binding, message):
    channel.basic_publish(exchange='amq.direct',
                          routing_key=binding,
                          body=message)


def subscribe_to_queue(channel, queue, callback):
    channel.basic_consume(queue=queue,
                          auto_ack=True,
                          on_message_callback=callback)

    channel.start_consuming()