﻿# Система обслуговування заявок при обмежених ресурсах

Алгоритм: MQS (Multilevel Queue Sheduling).

## Загальний принцип роботи

Ця стратегія розроблена для ситуації, коли заявки можуть бути легко класифіковані на декілька груп (в мене таких груп 3): системні, інтерактивні та пакетні.

Пріорітети у цих груп
* Системні (найвищий)
* Інтерактивні (середній)
* Пакетні (найнижчий)

Стратегія багаторівневої черги розділяє чергу готових процесів на декілька черг, в кожній з котрих знаходяться процеси з однаковими властивостями, і кожен із котрих може плануватися індивідуальною стратегією. В мене для системних та інтерактивних процесів стратегія Round Robin, а для пакетних процесів FIFO.

Взаємодія черг виконується за наступними правилами : ні один процес з більш низьким пріоритетом не може бути запущений, поки не виконаються процеси у всіх чергах з більш високим пріоритетом.